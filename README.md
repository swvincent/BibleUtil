# Bible Util

A set of utilities to make it easy to find all Bible references in plain text.  The parser can recognize abbreviations and a number of common spelling mistakes, and even those can be translated.  It is designed around the Protestant canon.

BibleUtil is a fork of [D-Haven/BibleUtilities](https://github.com/D-Haven/BibleUtilities)

Completed changes vs the original:
* Make book number (order) public, so it can be used as an identifier, etc.
* Allow book only references. Chapter is null if none specified
* Add ContiguousVerses property to Reference
* Set book numbers manually so they are the same across references and start at 1
* Removed Norwegian language support as I'm unable to support it
* Target .NET Standard 2.0

Potential future changes:
* Allow decimal place separator for chapter and verse
* Add apocryphal/deuterocanonical books
* Streamline abbreviations/add additional abbreviations
* Improve returned Reference object; having a null chapter for example isn't ideal
