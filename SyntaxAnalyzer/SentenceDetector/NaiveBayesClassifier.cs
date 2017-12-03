using System;
using System.Collections.Generic;
using System.Linq;
using Avaris.NLP.SyntaxAnalyzer.SentenceDetector.Models;

namespace Avaris.NLP.SyntaxAnalyzer.SentenceDetector
{
    public enum EOSOptions
    {
        None,
        LaplacianSmoothing
    }


    public class NaiveBayesClassifier : INaiveBayesClassifier
    {

        private const double LaplacianSmoothing = 1.0;
        private const double LaplacianSmoothingV = 3.0;
        private bool IsSmoothed;
        private readonly IEnumerable<PointStatistics> _data;

        public NaiveBayesClassifier(IEnumerable<PointStatistics> data)
        {
            _data = data;
        }


        public bool Classify(PointAttributeGroup attributes, EOSOptions option)
        {
            IsSmoothed = option == EOSOptions.LaplacianSmoothing ? true : false;

            double evidence = CalculateEvidence(attributes);
            double eosPP = CalculatePriorPrabability(attributes, true);
            double notEosPP = CalculatePriorPrabability(attributes, false);
            double eosLikelihood = CalculateLikelihood(attributes, true);
            double notEosLikelihood = CalculateLikelihood(attributes, false);

            //P(EOS|PreviousNext) = P(PreviousNext|EOS) * P(EOS) / P(PreviousNext)
            double eos = (eosLikelihood * eosPP) / evidence;

            //P(notEOS|PreviousNext) = P(PreviousNext|notEOS) * P(notEOS) / P(PreviousNext)
            double notEos = (notEosLikelihood * notEosPP) / evidence;

            if (eos > notEos)
                return true;
            return false;
        }

        public double CalculateLikelihood(PointAttributeGroup attributes, bool value)
        {
            //P(PreviousNext|EOS) P(PreviousNext|notEOS)
            return (_data.FirstOrDefault(t => t.Type == value).Attributes
                .FirstOrDefault(r => r.Group.Previous == attributes.Previous && r.Group.Next == attributes.Next)?.Count ?? 0.0) + (IsSmoothed ? LaplacianSmoothing : 0.0)
                    / _data.FirstOrDefault(t => t.Type == value).TotalCount + (IsSmoothed ? LaplacianSmoothingV : 0.0);
        }

        public double CalculateEvidence(PointAttributeGroup attributes)
        {
            //P(PreviousNext)
            return _data.SelectMany(x => x.Attributes)
                .Where(r => r.Group.Previous == attributes.Previous && r.Group.Next == attributes.Next)
                    .Sum(c => c.Count) + (IsSmoothed ? LaplacianSmoothing : 0.0)
                        / _data.Sum(x => x.TotalCount) + (IsSmoothed ? LaplacianSmoothingV : 0.0);
        }

        public double CalculatePriorPrabability(PointAttributeGroup attributes, bool value)
        {
            //P(EOS) | P(notEOS)
            return _data.FirstOrDefault(t => t.Type == value)
                .TotalCount + (IsSmoothed ? LaplacianSmoothing : 0.0)
                    / _data.Sum(x => x.TotalCount) + (IsSmoothed ? LaplacianSmoothingV : 0.0); 
        }
    }
}
