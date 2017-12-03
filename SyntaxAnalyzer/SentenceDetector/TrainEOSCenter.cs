using System;
using System.Collections.Generic;
using System.Linq;
using Avaris.NLP.SyntaxAnalyzer.SentenceDetector.Models;
using System.Text.RegularExpressions;

namespace Avaris.NLP.SyntaxAnalyzer.SentenceDetector
{
    public class TrainEOSCenter
    {
        private readonly string MarkUpPattern = @"(?<=(<Previous = '))\w*(?=('))|(?<=(Next = '))\w*(?=('))|(?<=(EOS = '))\w{4,5}(?=('))";

        public IEnumerable<PointStatistics> Train(string input)
        {
            string[] sentences = input.Split(new[] { "<S>", "</S>" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Replace("\r\n", "")).Where(x => !string.IsNullOrEmpty(x)).ToArray();
      
            var trainCorpus = new List<PointFeature>();

            for (int i = 0; i < sentences.Length; i++)
            {
                var matches = new Regex(MarkUpPattern).Matches(sentences[i]);

                for (int t = 0; t < matches.Count; t += 3)
                {
                    trainCorpus.Add(new PointFeature()
                    {
                        Feature = new PointAttributeGroup(matches[t].Value, matches[t + 1].Value),
                        IsEOS = Convert.ToBoolean(matches[t + 2].Value)
                    });
                }
            }
           return BindData(trainCorpus);
        }

        public IEnumerable<PointStatistics> BindData(IEnumerable<PointFeature> trainCorpus)
            =>
                trainCorpus.GroupBy(x => x.IsEOS).Select(u => new PointStatistics()
                {
                    Type = u.Key,
                    Attributes = u.GroupBy(t => new { t.Feature.Previous, t.Feature.Next }).Select(a => new AttributeStatistics()
                    {
                        Group =  new PointAttributeGroup() { Next = a.Key.Next, Previous = a.Key.Previous },
                        Count = a.Count()
                    }),
                    TotalCount = u.Count(),
                }).ToList();     
    }
}