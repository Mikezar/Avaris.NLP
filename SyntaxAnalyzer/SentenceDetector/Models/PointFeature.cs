namespace Avaris.NLP.SyntaxAnalyzer.SentenceDetector.Models
{
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
