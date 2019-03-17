#load "bloom.fsx"
open System
open System.IO

open Bloom

let generate (r: Random) =
  let i = Convert.ToInt32('a')
  let (a, b, c, d, e) =
    Convert.ToChar(r.Next() % 26 + i),
    Convert.ToChar(r.Next() % 26 + i),
    Convert.ToChar(r.Next() % 26 + i),
    Convert.ToChar(r.Next() % 26 + i),
    Convert.ToChar(r.Next() % 26 + i)

  sprintf "%c%c%c%c%c" a b c d e
 
let makeHashes<'a when 'a: equality> k (w: 'a) =
  let code   = Math.Abs(w.GetHashCode())
  let rand   = Random(code)
  let hashes = Array.zeroCreate k
  hashes.[0] <- code
  for i = 1 to k - 1 do
    hashes.[i] <- rand.Next()
  hashes

let num () =
  let bloom  = makeBloom 100 (makeHashes 4) 

  insert 2 bloom
  insert 3 bloom
  insert 4 bloom
  insert 12 bloom
  insert 13 bloom
  insert 15 bloom

  printfn "%A" ([0..20] |> List.map (fun v -> v, seen v bloom))

let words (bufferSize, hashSize) =

  let words = File.ReadAllLines "/usr/share/dict/words"
  let bloom = makeBloom bufferSize (makeHashes hashSize)

  for w in words do insert w bloom

  let mutable matches = []
  let r = Random()
  for i = 1 to 10000 do
    let v = generate r
    if seen v bloom then matches <- v :: matches

  printfn "%i matches: %A" matches.Length matches
  let hits = (matches |> List.filter (fun m -> words |> Array.contains m))
  printfn "%i correct hits: %A" hits.Length hits
  
let go () =
  let bufferSize = 5000000
  let hashSize   = 5
  words (bufferSize, hashSize)

go()