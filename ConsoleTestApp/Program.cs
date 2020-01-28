using System;
using BibleUtil;

namespace ConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var verseRef = Reference.Parse("Proverbs 13:7");

                Console.WriteLine($"{verseRef.Book.ToString()} is book # {verseRef.Book.BookNumber}");

                Console.WriteLine($"Verses contiguous: {verseRef.ContiguousVerses()}");

                var verseRef2 = Reference.Parse("Proverbs 13:7");

                Console.WriteLine($"{verseRef2.Book.ToString()} is book # {verseRef2.Book.BookNumber}");

                Console.WriteLine($"Verses contiguous: {verseRef2.ContiguousVerses()}");

            }
            catch (Exception caught)
            {
                Console.WriteLine(caught.Message);
            }

            Console.ReadLine();
        }
    }
}
