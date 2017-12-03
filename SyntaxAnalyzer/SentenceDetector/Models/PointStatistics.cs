using System.Collections.Generic;

namespace Avaris.NLP.SyntaxAnalyzer.SentenceDetector.Models
{
    public class PointStatistics
    {
        public bool Type { get; set; }

        public  IEnumerable<AttributeStatistics> Attributes { get; set; }

        public double TotalCount { get; set; }
    }
}
