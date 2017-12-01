using System.Text.RegularExpressions;
using Avaris.NLP.Core.Models;
using System.Collections.Generic;
using System;

namespace Avaris.NLP.Core.Rules
{
    public class BaseRuleConvention : IRuleConvention
    {
        private const string Word = @"^([A-Za-z]+-[A-Za-z-]+|[A-Za-z]+('s)?)";
        private const string Number = "^([0-9]+)";
        private const string Value = "^([0-9]+%)";
        private const string Currency = "^([$£]?[0-9]+[,.]?[0-9]+[a-z]*)";
        private const string Punctuation = "^([-—.,])";
        private const string SpecialSymbols = "^([%+=])";
        private const string DefaultRedundantPunctuation = @"(?<![A-Z,Mr,Dr,Ms,Mrs,Ltd])[.?!]\s?(?![0-9,a-z,\,.)])";
        private const string Blanks = @"\s{2,}";
        private const string Symbols = @"[!?]";
        private const string Abbreviation = @"\b((?<=[A-Z])\.?){2,}\b";
        private const string DateMonth = @"\b((?<=Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sept|Oct|Nov|Dec)[A-Z]{0,})\.?(?=\s?[0-9]{0,})";

        public virtual Match MatchRedundantPunctuation(string input, int index)
            =>
                new Regex(DefaultRedundantPunctuation).Match(input, index);
     
    }
}
