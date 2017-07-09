using System.Collections.Generic;
using Avaris.NLP.SyntaxAnalyzer.Normalization;

namespace Avaris.NLP.SyntaxAnalyzer.SentenceDetector
{
    public interface ISentenceDetector
    {
        IEnumerable<string> EOSDetector(bool preNormilizing = true);
        void SymbolAnalyzer(int initialPosition, int finalPosition, int spanLength);
        bool RuleObserver(int index);
        int GetCurrentPosition(int index);
    }
}
