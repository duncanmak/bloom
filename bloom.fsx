module Bloom

open System.Collections

type Bloom<'a> = Bloom of BitArray * ('a -> int[])

let makeBloom<'a> (size: int) hash =
  let buffer = BitArray size
  let hash (v: 'a) = hash v |> Array.map (fun i -> i % size)
  Bloom (buffer, hash)

let insert v (Bloom(buffer, hash)) =
  for h in hash (v) do 
    buffer.Set(h, true)

let seen v (Bloom(buffer, hash)) =
  hash v |> Array.forall (buffer.Get)
