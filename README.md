# Bible Util

BibleUtil is a fork of [D-Haven/BibleUtilities](https://github.com/D-Haven/BibleUtilities)

Completed changes:
* Make book number (order) public, so it can be used as an identifier, etc.
* Allow book only references. Chapter is null if none specified
* Add ContiguousVerses property to Reference
* Set book numbers manually so they are the same across references and start at 1
* Removed Norwegian language support as I'm unable to support it

Potential future changes:
* Add apocryphal/deuterocanonical books
* Streamline abbreviations/add additional abbreviations
* Improve returned Reference object; having a null chapter for example isn't ideal
