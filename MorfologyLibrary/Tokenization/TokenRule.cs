using System.Text.RegularExpressions;

namespace Avaris.NLP.MorfologyLibrary.Tokenization
{
    public class TokenRule
    {
        public TokenType Type { get; set; }
        public Regex Rule { get; set; }
    }
}
