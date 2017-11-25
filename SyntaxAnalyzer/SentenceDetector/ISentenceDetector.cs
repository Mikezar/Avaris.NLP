using System.Collections.Generic;
using Avaris.NLP.Core.Units;

namespace Avaris.NLP.SyntaxAnalyzer.SentenceDetector
{
    public interface ISentenceDetector
    {
        IEnumerable<ISentence> DetectEnd();

        IEnumerable<int> DetectPositions();
    }
}
