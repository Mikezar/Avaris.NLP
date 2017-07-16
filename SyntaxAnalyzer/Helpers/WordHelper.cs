using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaris.NLP.SyntaxAnalyzer.Helpers
{
    public static class WordHelper
    {
        public static string[] SplitToWords(string sentence)
        {
            return sentence.Split(' ').ToArray();
        }
    }
}
