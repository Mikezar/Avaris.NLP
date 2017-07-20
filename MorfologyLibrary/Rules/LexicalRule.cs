using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaris.NLP.MorfologyLibrary.Rules
{
    public static class LexicalRule
    {
        public const string Word = @"^([A-Za-z]+-[A-Za-z-]+|[A-Za-z]+('s)?)";
        public const string Number = "^([0-9]+)";
        public const string Value = "^([0-9]+%)";
        public const string Currency = "^([$£]?[0-9]+[,.]?[0-9]+[a-z]*)";
        public const string Punctuation = "^([-—.,])";
        public const string SpecialSymbols = "^([%+=])";   
        public const string RedundantPunctuation = @"[.,]\s?(?![0-9])";
        public const string Blanks = @"\s{2,}";
        public const string Symbols = @"[!?]";
        public const string Abbreviation = @"\b((?<=[A-Z])\.?){2,}\b";
        public const string DateMonth = @"\b((?<=Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sept|Oct|Nov|Dec)[A-Z]{0,})\.?(?=\s?[0-9]{0,})";
    }
}
