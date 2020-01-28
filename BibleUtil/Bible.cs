#region Copyright 2016 D-Haven.org

//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BibleUtil
{
    /// <summary>
    ///     Provide a convenience class to get the already translated books
    ///     of the Bible.  Organizes the books in order, and categorizes them
    ///     as New and Old Testaments.
    /// </summary>
    public class Bible
    {
        private readonly List<Book> newTestament;
        private readonly List<Book> oldTestament;
        private CultureInfo bibleCulture;

        public Bible() : this(CultureInfo.CurrentCulture)
        {
        }

        public Bible(CultureInfo culture)
        {
            bibleCulture = culture;

            oldTestament = new List<Book>
            {
                new Book(1, "Genesis", 50, Culture), // Gen
                new Book(2, "Exodus", 40, Culture), // Exod
                new Book(3, "Leviticus", 27, Culture), // Lev
                new Book(4, "Numbers", 36, Culture), // Num
                new Book(5, "Deuteronomy", 34, Culture), // Deut
                new Book(6, "Joshua", 24, Culture), // Josh
                new Book(7, "Judges", 21, Culture), // Judg
                new Book(8, "Ruth", 4, Culture), // Ruth
                new Book(9, "OneSamuel", 31, Culture), // 1Sam
                new Book(10, "TwoSamuel", 24, Culture), // 2Sam
                new Book(11, "OneKings", 22, Culture), // 1Kgs
                new Book(12, "TwoKings", 25, Culture), // 2Kgs
                new Book(13, "OneChronicles", 29, Culture), // 1Chr
                new Book(14, "TwoChronicles", 36, Culture), // 2Chr
                new Book(15, "Ezra", 10, Culture), // Ezra
                new Book(16, "Nehemiah", 13, Culture), // Neh
                new Book(17, "Esther", 10, Culture), // Esth
                new Book(18, "Job", 42, Culture), // Job
                new Book(19, "Psalms", 150, Culture), // Ps
                new Book(20, "Proverbs", 31, Culture), // Prov
                new Book(21, "Ecclesiastes", 12, Culture), // Eccl
                new Book(22, "SongOfSolomon", 8, Culture), // Song
                new Book(23, "Isaiah", 66, Culture), // Isa
                new Book(24, "Jeremiah", 52, Culture), // Jer
                new Book(25, "Lamentations", 5, Culture), // Lam
                new Book(26, "Ezekiel", 48, Culture), // Ezek
                new Book(27, "Daniel", 12, Culture), // Dan
                new Book(28, "Hosea", 14, Culture), // Hos
                new Book(29, "Joel", 3, Culture), // Joel
                new Book(30, "Amos", 9, Culture), // Amos
                new Book(31, "Obadaiah", 1, Culture), // Obad
                new Book(32, "Jonah", 4, Culture), // Jonah
                new Book(33, "Micah", 7, Culture), // Mic
                new Book(34, "Nahum", 3, Culture), // Nah
                new Book(35, "Habakkuk", 3, Culture), // Hab
                new Book(36, "Zephaniah", 3, Culture), // Zeph
                new Book(37, "Haggai", 2, Culture), // Hag
                new Book(38, "Zechariah", 14, Culture), // Zech
                new Book(39, "Malachai", 4, Culture) // Mal
            };

            newTestament = new List<Book>
            {
                new Book(40, "Matthew", 28, Culture), // Matt
                new Book(41, "Mark", 16, Culture), // Mark
                new Book(42, "Luke", 24, Culture), // Luke
                new Book(43, "John", 21, Culture), // John
                new Book(44, "Acts", 28, Culture), // Acts
                new Book(45, "Romans", 16, Culture), // Rom
                new Book(46, "OneCorinthians", 16, Culture), // 1Cor
                new Book(47, "TwoCorinthians", 13, Culture), // 2Cor
                new Book(48, "Galatians", 6, Culture), // Gal
                new Book(49, "Ephesians", 6, Culture), // Eph
                new Book(50, "Philippians", 4, Culture), // Phil
                new Book(51, "Colossians", 4, Culture), // Col
                new Book(52, "OneThessalonians", 5, Culture), // 1Thess
                new Book(53, "TwoThessalonians", 3, Culture), // 2Thess
                new Book(54, "OneTimothy", 6, Culture), // 1Tim
                new Book(55, "TwoTimothy", 4, Culture), // 2Tim
                new Book(56, "Titus", 3, Culture), // Titus
                new Book(57, "Philemon", 1, Culture), // Phlm
                new Book(58, "Hebrews", 13, Culture), // Heb
                new Book(59, "James", 5, Culture), // Jas
                new Book(60, "OnePeter", 5, Culture), // 1Pet
                new Book(61, "TwoPeter", 3, Culture), // 2Pet
                new Book(62, "OneJohn", 5, Culture), // 1John
                new Book(63, "TwoJohn", 1, Culture), // 2John
                new Book(64, "ThreeJohn", 1, Culture), // 3John
                new Book(65, "Jude", 1, Culture), // Jude
                new Book(66, "Revelation", 22, Culture) // Rev
            };
        }

        public IList<Book> OldTestament => oldTestament;

        public IList<Book> NewTestament => newTestament;

        public IEnumerable<Book> AllBooks => oldTestament.Union(newTestament);

        public CultureInfo Culture
        {
            get => bibleCulture;
            set
            {
                if (!Equals(bibleCulture, value))
                {
                    bibleCulture = value;

                    foreach (var book in AllBooks)
                        book.Culture = value;
                }
            }
        }
    }
}