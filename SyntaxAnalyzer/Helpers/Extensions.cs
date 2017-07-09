using System.Collections.Generic;
using System.IO;

namespace Avaris.NLP.SyntaxAnalyzer.Helpers
{
    public static  class Extensions
    {
        private static readonly List<string> _extensions = new List<string>()
        {
            ".txt",
            ".doc"
        };

        public static bool CheckExtension(string path)
        {
            return _extensions.Contains(Path.GetExtension(path));
        }
    }
}
