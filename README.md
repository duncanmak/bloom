# Simple Bloom Filter implementation in F#

March 2019

Duncan Mak <duncanmak@gmail.com>

Reference: http://codekata.com/kata/kata05-bloom-filters/

## Instructions:

To run:
```
fsharpi test.fsx
```

Sample output:
```
yomigana:bloom (master)$ fsharpi test.fsx 
9 matches: ["vbhkk"; "eaved"; "olcwx"; "glump"; "riavu"; "blowy"; "ozone"; "duryf"; "bluff"]
5 correct hits: ["eaved"; "glump"; "blowy"; "ozone"; "bluff"]
```

## Interesting papers

[Why we didn't use a bloom filter](https://www.dr-josiah.com/2012/03/why-we-didnt-use-bloom-filter.html)

Interesting discussion on bloom filter's impact on cache line and memory locality.

[Why Bloom filters work the way they do](http://www.michaelnielsen.org/ddi/why-bloom-filters-work-the-way-they-do/)

A good review of the underlying math to understand how to tweak the parameters to get the desired probability.

[The Bloom Paradox: When not to Use a Bloom Filter?](http://webee.technion.ac.il/~isaac/p/infocom12_paradox.pdf)

More details on the pros / cons of using a bloom filter.

[The Bloom Filter](https://www.i-programmer.info/programming/theory/2404-the-bloom-filter.html?start=1)

Technique for generating `k` hash functions.