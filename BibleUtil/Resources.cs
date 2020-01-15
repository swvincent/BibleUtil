using System.Reflection;
using System.Resources;

namespace BibleUtil
{
    internal static class ResourceManagement
    {
        static ResourceManagement()
        {
            var assembly = typeof(ResourceManagement).GetTypeInfo().Assembly;
            Books = new ResourceManager("BibleUtil.Resources.Books", assembly);
            CommonMistakes = new ResourceManager("BibleUtil.Resources.CommonMistakes", assembly);
            StandardAbbreviations = new ResourceManager("BibleUtil.Resources.StandardAbbreviations",
                assembly);
            ThompsonAbbreviations = new ResourceManager("BibleUtil.Resources.ThompsonAbbreviations",
                assembly);
        }

        public static ResourceManager Books { get; }
        public static ResourceManager CommonMistakes { get; }
        public static ResourceManager StandardAbbreviations { get; }
        public static ResourceManager ThompsonAbbreviations { get; }
    }
}