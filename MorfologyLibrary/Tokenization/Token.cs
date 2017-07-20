namespace Avaris.NLP.MorfologyLibrary.Tokenization
{
   public class Token
    {
        public string Value { get; set; }

        public TokenType Type { get; set; }

        public bool IsEmpty => string.IsNullOrEmpty(Value);
    }
}
