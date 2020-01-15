using System.Reflection;
using System.Resources;

namespace BibleUtilities
{
    internal static class ResourceManagement
    {
        static ResourceManagement()
        {
            var assembly = typeof(ResourceManagement).GetTypeInfo().Assembly;
            Books = new ResourceManager("BibleUtilities.Resources.Books", assembly);
            CommonMistakes = new ResourceManager("BibleUtilities.Resources.CommonMistakes", assembly);
            StandardAbbreviations = new ResourceManager("BibleUtilities.Resources.StandardAbbreviations",
                assembly);
            ThompsonAbbreviations = new ResourceManager("BibleUtilities.Resources.ThompsonAbbreviations",
                assembly);
        }

        public static ResourceManager Books { get; }
        public static ResourceManager CommonMistakes { get; }
        public static ResourceManager StandardAbbreviations { get; }
        public static ResourceManager ThompsonAbbreviations { get; }
    }
}