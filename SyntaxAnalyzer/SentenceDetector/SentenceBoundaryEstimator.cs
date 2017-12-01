using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Avaris.NLP.SyntaxAnalyzer.SentenceDetector.Models;

namespace Avaris.NLP.SyntaxAnalyzer.SentenceDetector
{
    public class SentenceBoundaryEstimator
    {
        private IDictionary<string, string> EosRules = new Dictionary<string, string>()
        {
            {"UppercaseAheadPunctuation", @"(?<=[A-Z])[.](?=[.,])"},
            {"LowercaseAheadPunctuation", @"(?<=[a-z])[.](?=[.,])"},
            {"LowercaseAheadSymbols", @"(?<=[a-z])[.]\s?(?=[()])"},
            {"PunctuationAheadPunctuation", @"[.,]?[.](?=[.,a-z])"},
            {"PunctuationAheadSpace", @"(?<=[.])[.]\s"},
            {"TitleAheadUnknown", @"(?<=Mr|Mrs|Ms|Dr)[.]"},
            {"LowercaseAheadUppercase", @"(?<=[a-z])[.?!]\s?(?=[A-Z])"},
            {"LowercaseAheadQuote", "(?<=[a-z])[.?!]\\s?(?=[\"”])"},
            {"LowercaseAheadSpace", @"(?<=[a-z])[.?!]\s"},
            {"AbbreviationAheadUnknown", @"\b((?<=Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sept|Oct|Nov|Dec))\."},
            {"UppercaseAheadUppercase", @"(?<=[A-Z]).(?=[A-Z])"},
            {"UppercaseAheadUnknown", @"(?<=[A-Z])[.]"},
            {"DigitAheadDigit", @"(?<=[0-9])[.](?=[0-9])"},
            {"DigitAheadSpace", @"(?<=[0-9])[.]"},
        };

        public virtual PointAttributeGroup MatchPointAttribute(string input, int index)
        {
            foreach (var rule in EosRules)
            {
                if (new Regex(rule.Value).Match(input, index).Index == index)
                {
                    var attributes = rule.Key.Split(new[] { "Ahead" }, StringSplitOptions.None);
                    return new PointAttributeGroup(attributes[0], attributes[1]);
                }
            }

            return new PointAttributeGroup() { Previous = RegisterGroup.Unknown, Next = RegisterGroup.Unknown };
        }
    }
}
