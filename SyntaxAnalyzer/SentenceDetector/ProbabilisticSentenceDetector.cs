using Avaris.NLP.Core.Units;
using Avaris.NLP.SyntaxAnalyzer.SentenceDetector.Models;
using System.Collections.Generic;

namespace Avaris.NLP.SyntaxAnalyzer.SentenceDetector
{
    public class ProbabilisticSentenceDetector : DefaultSentenceDetector
    {
        private readonly SentenceBoundaryEstimator _estimator;

        private readonly INaiveBayesClassifier _classifier;


        public ProbabilisticSentenceDetector(IText text, IEnumerable<PointStatistics> data) : base(text)
        {
            _classifier = new NaiveBayesClassifier(data);
            _estimator = new SentenceBoundaryEstimator();
        }

        protected override bool Estimator(int index)
        {
         return _classifier.Classify(_estimator.MatchPointAttribute(_text.Source, index),
             EOSOptions.LaplacianSmoothing);
        }
    }
}
