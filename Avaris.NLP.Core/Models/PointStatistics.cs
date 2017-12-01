using System.Collections.Generic;

namespace Avaris.NLP.Core.Models
{
    public class PointStatistics
    {
        public bool Type { get; set; }

        public  IEnumerable<PointAttributeGroup> Feature { get; set; }

        public double Count { get; set; }
    }
}
