using Avaris.NLP.SyntaxAnalyzer.SentenceDetector.Models;

namespace Avaris.NLP.SyntaxAnalyzer.SentenceDetector
{
   public  interface INaiveBayesClassifier
    {
        bool Classify(PointAttributeGroup attributes, EOSOptions option);
    }
}
