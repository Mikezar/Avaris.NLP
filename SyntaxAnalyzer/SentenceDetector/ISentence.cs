using System.Collections.Generic;

namespace Avaris.NLP.SyntaxAnalyzer.SentenceDetector
{
    public interface ISentence
    {
        IEnumerable<string> GetSentences();
        char[] GetSeparators();
        void AddSubstring(string substring);
    }
}
