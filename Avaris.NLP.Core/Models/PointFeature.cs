using System.Collections.Generic;
using System.Linq;

namespace Avaris.NLP.Core.Models
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
        Title,
        Unknown
            
    }

    public class PointAttributeGroup
    {
        private IDictionary<string, RegisterGroup> _groups = new Dictionary<string, RegisterGroup>()
        {
            {"Uppercase", RegisterGroup.Uppercase},
            {"Lowercase", RegisterGroup.Lowercase},
            {"Punctuation", RegisterGroup.Punctuation},
            {"Symbols", RegisterGroup.Symbols},
            {"Quote", RegisterGroup.Quote},
            {"Digit", RegisterGroup.Digit},
            {"Abbreveation", RegisterGroup.Abbreviation},
            {"Space", RegisterGroup.Space},
            {"Title", RegisterGroup.Title},
            {"Unknown", RegisterGroup.Unknown},
        };

        public RegisterGroup Previous { get; set; }

        public RegisterGroup Next { get; set; }


        public PointAttributeGroup()
        {

        }

        public PointAttributeGroup(string prev, string next)
        {
            Previous = GetAttribute(prev);
            Next = GetAttribute(next);
        }


        private RegisterGroup GetAttribute(string input)
        {
            if (_groups.ContainsKey(input))
                return _groups[input];
            return 0;
        }
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
