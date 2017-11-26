using System.Text.RegularExpressions;

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



        private const string StandardPointCase = @"(?<=[a-z])[.]\s?";
        private const string UpperCasePointAheadPunctuation = @"(?<=[A-Z])[.](?=[.,])";
        private const string LowercasePointAheadPunctuation = @"(?<=[a-z])[.](?=[.,])";
        private const string PunctuationPointAheadPunctuation = @"[.,]?[.](?=[.,a-z]))";
        private const string TitlePoint = @"(?<=Mr|Mrs|Ms|Dr)[.]";
        private const string LowerCasePointAheadUppercase = @"(?<=[a-z])[.?!]\s?(?=[A-Z])";
        private const string LowerCasePointAheadQuote = "(?<=[a-z])[.?!]\\s?(?=[\"”])";
        private const string LowercasePointAheadSpace = @"(?<=[a-z])[.?!]\s";
        private const string AbbreviationDatePoint = @"\b((?<=Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sept|Oct|Nov|Dec))\.";
        private const string UpperCasePointAheadUppercase = @"(?<=[A-Z]).(?=[A-Z])";
        private const string UpperCasePointAheadSpace = @"(?<=[A-Z])[.]";
        private const string DigitPointAheadDigit = @"(?<=[0-9])[.](?=[0-9])";
        private const string DigitPointAheadSpace = @"(?<=[0-9])[.]";
        private const string LowercasePointAheadSymbols = @"(?<=[a-z])[.]\s?(?=[()])";


        public virtual Match MatchRedundantPunctuation(string input, int index)
            =>
                new Regex(DefaultRedundantPunctuation).Match(input, index);
        
    }
}
