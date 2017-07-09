using Avaris.NLP.SyntaxAnalyzer.SentenceDetector;
namespace Avaris.NLP.SyntaxAnalyzer
{
    public interface IText
    {
        ISentence Sentence { get; set; }
        string OriginalText { get; set; }
    }
}
