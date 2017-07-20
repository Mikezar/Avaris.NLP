using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;

namespace Avaris.NLP.SyntaxAnalyzer.Normalization
{
    public class Normalization : INormalization
    {
        private const string PunctuationSymbols = "[«»‹›:;‘\"’“”‚„¿¡§¶•—–]";
        private const string EmailPattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
        private const string URLPattern = @"(www|ftp|http)[^\s]+";
        //Regex regex = new Regex("[.«»‹›:;‘\"’“”,„¿!&?¡§¶•—^#*@\\`\\(\\)\\[\\]\\(\\)\\{\\}=]");

        private Dictionary<char, char> DiacriticSymbols = new Dictionary<char, char>()
        {
            {'À', 'A'},
            {'Á', 'A'},
            {'Â', 'A'},
            {'Ã', 'A'},
            {'Ä', 'A'},
            {'Å', 'A'},
            {'Æ', 'A'},
            {'Ą', 'A'},
            {'à', 'a'},
            {'á', 'a'},
            {'â', 'a'},
            {'ã', 'a'},
            {'ä', 'a'},
            {'å', 'a'},
            {'æ', 'a'},
            {'ą', 'a'},

            {'Ç', 'C'},
            {'Ć', 'C'},
            {'Ĉ', 'C'},
            {'Č', 'C'},
            {'ç', 'c'},
            {'ć', 'c'},
            {'ĉ', 'c'},
            {'č', 'c'},

            {'È', 'E'},
            {'É', 'E'},
            {'Ê', 'E'},
            {'Ë', 'E'},
            {'Ę', 'E'},
            {'Ě', 'E'},
            {'è', 'e'},
            {'é', 'e'},
            {'ê', 'e'},
            {'ë', 'e'},
            {'ę', 'e'},
            {'ě', 'e'},

            {'Ì', 'I'},
            {'Í', 'I'},
            {'Î', 'I'},
            {'Ï', 'I'},
            {'ì', 'i'},
            {'í', 'i'},
            {'î', 'i'},
            {'ï', 'i'},

            {'Ò', 'O'},
            {'Ó', 'O'},
            {'Ô', 'O'},
            {'Œ', 'O'},
            {'Õ', 'O'},
            {'Ö', 'O'},
            {'Ø', 'O'},
            {'ò', 'o'},
            {'ó', 'o'},
            {'ô', 'o'},
            {'œ', 'o'},
            {'õ', 'o'},
            {'ö', 'o'},
            {'ø', 'o'},

            {'Ù', 'U'},
            {'Ú', 'U'},
            {'Û', 'U'},
            {'Ü', 'U'},
            {'ù', 'u'},
            {'ú', 'u'},
            {'û', 'u'},
            {'ü', 'u'},

            {'Ý', 'Y'},
            {'Ÿ', 'Y'},
            {'ý', 'y'},
            {'ÿ', 'y'},
        };

        public string PreNormalizationToEOSDetection(string input, bool removePunctuationSymbols, bool substituteDiacritic, bool removeURLs, bool removeEmails)
        {
            if (String.IsNullOrEmpty(input)) throw new NullReferenceException("The content contains nothing.");

            if (removePunctuationSymbols) input = RemovePunctuationSymbols(input);

            if (substituteDiacritic) input = RemoveDiacritic(input);

            if (removeURLs) input = RemoveURLs(input);

            if (removeEmails) input = RemoveEmails(input);

            if (!string.IsNullOrEmpty(input))
            {
                return input;
            }
            throw new Exception("Text normalizing finished with empty string. Check the text encoding");

        }

        public string RemovePunctuationSymbols(string input)
        {
            return Regex.Replace(input, PunctuationSymbols, "").Replace("\r\n", "");
        }

        public string RemoveDiacritic(string input)
        {
            var diacritics = input.Where(x => DiacriticSymbols.ContainsKey(x));

            foreach(var d in diacritics)
            {
                input = input.Replace(d, DiacriticSymbols[d]);
            }

            return input;
        }

        public string RemoveURLs(string input)
        {
            return Regex.Replace(input, URLPattern, "");
        }

        public string RemoveEmails(string input)
        {
            return Regex.Replace(input, EmailPattern, "");
        }
    }
}
