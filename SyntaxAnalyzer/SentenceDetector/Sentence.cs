using System.Collections.Generic;

namespace Avaris.NLP.SyntaxAnalyzer.SentenceDetector
{
    public class Sentence : ISentence
    {
        private readonly char[] _separators = new char[] { '!', '?', '.' };

        private List<string> _sentences = new List<string>();


        public void AddSubstring(string substring)
        {
            _sentences.Add(substring);
        }

        public IEnumerable<string> GetSentences()
        {
            return _sentences;
        }

        public char[] GetSeparators()
        {
            return _separators;
        }
    }
}
