using System.Collections.Generic;
using System.Linq;
using Avaris.NLP.Core.Rules;
using Avaris.NLP.Core.Units;
using Avaris.NLP.Core.Units.Concrete;


namespace Avaris.NLP.SyntaxAnalyzer.SentenceDetector
{
    public class ProbabilisticSentenceDetector : DefaultSentenceDetector
    {
        public ProbabilisticSentenceDetector(IText text) : base(text) { }

        protected override bool Estimator(int index)
        {
            
        }
    }
}
