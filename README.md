# Bible Util

BibleUtil is a fork of [D-Haven/BibleUtilities](https://github.com/D-Haven/BibleUtilities) that I started modifying to meet my specific needs.

Completed changes:
* Make book number (order) public, so it can be used as an identifier, etc.
* Allow book only references. Chapter is 0 if none specified
* Add ContiguousVerses property to Reference
* Set book numbers manually so they are the same across references and start at 1
* Removed Norwegian language support to simplify other changes I had planned

Potential future changes:
* Change how book only references work; I don't like having chapter to set 0
* Streamline abbreviations/add additional abbreviations
* Add apocryphal/deuterocanonical books
