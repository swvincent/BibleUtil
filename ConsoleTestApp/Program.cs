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

                Console.WriteLine(verseRef);

                Console.WriteLine($"{verseRef.Book.ToString()} is book # {verseRef.Book.BookNumber}");

                Console.WriteLine($"Verses contiguous: {verseRef.ContiguousVerses()}");
            }
            catch (Exception caught)
            {
                Console.WriteLine(caught.Message);
            }

            Console.ReadLine();
        }
    }
}
