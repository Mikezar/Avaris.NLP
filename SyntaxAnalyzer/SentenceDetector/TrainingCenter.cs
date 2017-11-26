using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaris.NLP.SyntaxAnalyzer.SentenceDetector
{
    public class TrainingCenter
    {

        public IEnumerable<PointStatistics> BindData(IEnumerable<PointFeature> trainCorpus)
        {
            return trainCorpus.GroupBy(x => x.IsEOS).Select(u => new PointStatistics()
            {
                Type = u.Key,
                Feature = u.Select(t => new PointAttributeGroup() { Next = t.Feature.Next, Previous = t.Feature.Previous }),
                Count = u.Count(),
            }).ToList();
        }
    }
}
