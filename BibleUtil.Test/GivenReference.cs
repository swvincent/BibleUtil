﻿using System;
using System.Globalization;
using System.Linq;
using Xunit;

namespace BibleUtil.Test
{
    public class GivenReference
    {
        [Fact]
        public void ShouldParseChapterOnlyReferences()
        {
            const string text = "Gal. 3";

            var reference = Reference.Parse(text, new CultureInfo("en"));

            Assert.Equal("Galatians", reference.Book.ToString());
            Assert.Equal(3, reference.Chapter);
            Assert.Empty(reference.Verses);
        }

        [Fact]
        public void ShouldParseOneChapterBooksWithoutChapter()
        {
            const string text = "II John 10";

            var reference = Reference.Parse(text, new CultureInfo("en"));

            Assert.Equal("2 John", reference.Book.ToString());
            Assert.Equal(1, reference.Chapter);
            Assert.Contains(10, reference.Verses);
            Assert.Single(reference.Verses);
        }

        [Fact]
        public void ShouldParseOneChapterReferenceWithVerseRange()
        {
            const string text = "3 Jn 5-7";

            var reference = Reference.Parse(text, new CultureInfo("en"));

            Assert.Equal("3 John", reference.Book.ToString());
            Assert.Equal(1, reference.Chapter);
            Assert.Equal(3, reference.Verses.Length);

            foreach (var i in Enumerable.Range(5, 3))
                Assert.Contains(i, reference.Verses);
        }

        [Fact]
        public void ShouldParseReferenceWithCommaDelimitedVerses()
        {
            const string text = "Ge 2:4,6,8";

            var reference = Reference.Parse(text, new CultureInfo("en"));
            Assert.Equal("Genesis", reference.Book.ToString());
            Assert.Equal(2, reference.Chapter);
            Assert.Contains(4, reference.Verses);
            Assert.Contains(6, reference.Verses);
            Assert.Contains(8, reference.Verses);
            Assert.Equal(3, reference.Verses.Length);
        }

        [Fact]
        public void ShouldParseReferenceWithCommasAndRange()
        {
            const string text = "Galatians 6:2,4-5,8,16-18";

            var reference = Reference.Parse(text, new CultureInfo("en"));

            Assert.Equal("Galatians", reference.Book.ToString());
            Assert.Equal(6, reference.Chapter);
            Assert.Equal(7, reference.Verses.Length);

            Assert.Contains(2, reference.Verses);
            Assert.Contains(8, reference.Verses);

            foreach (var i in Enumerable.Range(4, 2).Union(Enumerable.Range(16, 3)))
                Assert.Contains(i, reference.Verses);
        }

        [Fact]
        public void ShouldParseReferenceWithVerseRange()
        {
            const string text = "Heb. 12:1-4";

            var reference = Reference.Parse(text, new CultureInfo("en"));

            Assert.Equal("Hebrews", reference.Book.ToString());
            Assert.Equal(12, reference.Chapter);
            Assert.Equal(4, reference.Verses.Length);

            foreach (var i in Enumerable.Range(1, 4))
                Assert.Contains(i, reference.Verses);
        }

        [Fact]
        public void ShouldParseSimpleReference()
        {
            const string text = "1 John 1:9";

            var reference = Reference.Parse(text, new CultureInfo("en"));

            Assert.Equal("1 John", reference.Book.ToString());
            Assert.Equal(1, reference.Chapter);
            Assert.Contains(9, reference.Verses);
            Assert.Single(reference.Verses);
        }

        [Fact]
        public void ShouldIndicateContiguousForOneVerse()
        {
            const string text = "John 3:16";

            var reference = Reference.Parse(text, new CultureInfo("en"));

            Assert.True(reference.ContiguousVerses());
        }

        [Fact]
        public void ShouldIndicateContiguousForTwoVerses()
        {
            const string text = "John 3:16-17";

            var reference = Reference.Parse(text, new CultureInfo("en"));

            Assert.True(reference.ContiguousVerses());
        }

        [Fact]
        public void ShouldIndicateContiguousForFiveVerses()
        {
            const string text = "Genesis 1:1-5";

            var reference = Reference.Parse(text, new CultureInfo("en"));

            Assert.True(reference.ContiguousVerses());
        }

        [Fact]
        public void ShouldNotIndicateContiguousVerses()
        {
            const string text = "1 John 1:1,5";

            var reference = Reference.Parse(text, new CultureInfo("en"));

            Assert.False(reference.ContiguousVerses());
        }

        [Fact]
        public void ShouldParseBookOnlyReference()
        {
            const string text = "Acts";

            var reference = Reference.Parse(text, new CultureInfo("en"));

            Assert.Equal("Acts", reference.Book.ToString());
            Assert.Null(reference.Chapter);
            Assert.Empty(reference.Verses);
            Assert.Equal("Acts", reference.ToString());
        }

        [Fact]
        public void ShouldScanForVersesInsideParenthesis()
        {
            var references = Reference.Scan("This is superfluous text with a reference (1 Co 13:3)");

            Assert.Single(references);
            Assert.Contains(Reference.Parse("1 Cor. 13:3"), references);
        }

        [Fact]
        public void ShouldScanSemicolonSeparatedVerses()
        {
            var references = Reference.Scan("Lorem ipsum dolor -- 2 Kings 5:23;Prov. 3:13", new CultureInfo("en"));

            Assert.Equal(2, references.Count);

            Assert.Contains(Reference.Parse("2 K 5:23", new CultureInfo("en")), references);
            Assert.Contains(Reference.Parse("Pr 3:13", new CultureInfo("en")), references);
        }

        [Fact]
        public void ShouldHaveSameBookNumberInTwoReferencesToTheSameBook()
        {
            var ref1 = Reference.Parse("Proverbs 13:7");
            var ref2 = Reference.Parse("Proverbs 13:7");

            Assert.True(ref1.Book.BookNumber == ref2.Book.BookNumber);
        }

        [Fact]
        public void ShouldThrowExceptionForInvalidRange()
        {
            Assert.Throws<FormatException>(() => Reference.Parse("Gen. 3:4-5-9", new CultureInfo("en")));
        }

        [Fact]
        public void ShouldThrowExceptionIfChapterIsTooHigh()
        {
            Assert.Throws<FormatException>(() => Reference.Parse("Psalms 256:128", new CultureInfo("en")));
        }

        [Fact]
        public void ShouldThrowExceptionIfRangeIsReversed()
        {
            Assert.Throws<FormatException>(() => Reference.Parse("Lev. 6:12-8", new CultureInfo("en")));
        }

        [Fact]
        public void ShouldThrowExceptionOnChapterRanges()
        {
            Assert.Throws<FormatException>(() => Reference.Parse("2 Cor. 5-7", new CultureInfo("en")));
        }
    }
}