using System;
using Avaris.NLP.SyntaxAnalyzer.SentenceDetector;

namespace Avaris.NLP.SyntaxAnalyzer
{
   public  class TextContext : IText
   {
        public ISentence Sentence { get; set; }
        
        public string OriginalText { get; set; }

        public TextContext(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            OriginalText = text;
        }
    }
}
