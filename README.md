# Bible Util

BibleUtil is a fork of [D-Haven/BibleUtilities](https://github.com/D-Haven/BibleUtilities) that I started modifying to meet my specific needs. I was going to use it for a Bible journaling application but have since decided not to continue that project.

Completed changes:
* Make book number (order) public, so it can be used as an ID field
* Allow book only references. Chapter is 0 if none specified
* Add ContiguousVerses property to Reference
* Set book numbers manually so they are the same across references and start at 1
* Removed Norwegian language support to simplify other changes I had planned

Planned changes I did not get to:
* Streamline abbreviations and add additional abbreviations
* Add apocryphal/deuterocanonical books
