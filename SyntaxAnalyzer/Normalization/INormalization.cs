namespace Avaris.NLP.SyntaxAnalyzer.Normalization
{
    public interface INormalization
    {
        string PreNormalizationToEOSDetection(string input, bool removeSpecialSymbols = true, bool substituteDiacritic = true, bool removeURLs = false, bool removeEmails = false);
        string RemovePunctuationSymbols(string input);
        string RemoveDiacritic(string input);
        string RemoveURLs(string input);
        string RemoveEmails(string input);
    }
}
