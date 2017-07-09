namespace Avaris.NLP.MorfologyLibrary.Rules
{
    public static  class SentenceRule
    {
        public const string Blanks = @"\s{2,}";
        public const string Symbols = @"[!?]";
        public const string Abbreviation = @"\b((?<=[A-Z])\.?){2,}\b";
        public const string DateMonth = @"\b((?<=Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sept|Oct|Nov|Dec)[A-Z]{0,})\.?(?=\s?[0-9]{0,})";
    }
}
