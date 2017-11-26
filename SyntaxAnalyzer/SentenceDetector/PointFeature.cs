using System;

namespace Avaris.NLP.SyntaxAnalyzer.SentenceDetector
{
    public enum RegisterGroup
    {
        Uppercase = 1,
        Lowercase,
        Punctuation,
        Symbols,
        Quote,
        Digit,
        Abbreviation,
        Space,
        Title              
    }

    public class PointAttributeGroup
    {

        public RegisterGroup Previous { get; set; }

        public RegisterGroup Next { get; set; }
    }

    public class PointFeature
    {
        public bool IsEOS { get; set; }

        public PointAttributeGroup Feature { get; set; }

        public PointFeature(RegisterGroup previous, RegisterGroup next, bool isEOS)
        {
            Feature = new PointAttributeGroup()
            {
                Previous = previous,
                Next = next
            };
            IsEOS = isEOS;
        }
    }
}
