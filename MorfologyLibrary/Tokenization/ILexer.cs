using System.Collections.Generic;

namespace Avaris.NLP.MorfologyLibrary.Tokenization
{
    public interface ILexer
    {
        IList<Token> Scanner();
        void Evaluator(IList<Token> tokens);
        void AddRule(TokenType type, string rule);
        IList<Token> Tokenize(string formattedSentence);
        string STreeBuilder(IList<Token> tokens);
    }
}
