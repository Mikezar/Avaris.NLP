using System;
using System.Linq;
using Avaris.NLP.Dictionary;
using Avaris.NLP.SyntaxAnalyzer.IO;

namespace Avaris.NLP.SyntaxAnalyzer.EarleyParser
{
    public class CFGrammar : Grammar
    {
        private readonly string _sourceString;
        private readonly ITextReader _textReader;

        public CFGrammar(string sourceString, ITextReader reader)
        {
            if (string.IsNullOrEmpty(sourceString)) throw new NullReferenceException(sourceString);
            _sourceString = sourceString;
            _textReader = reader;

            RegisterPartOfSpeech();
            ProductionInit();
        }

        private void ProductionInit()
        {

            Production[] sRHS = { new Production(new Word[] { new NonTerminal("NP"), new NonTerminal("VP") })};
            AddProduction(sRHS, "S");

            Production[] npRHS = { new Production(new Word[] { new Terminal("Pronoun")}), new Production(new Word[] { new Terminal("Proper-Noun") }), new Production(new Word[] { new Terminal("DT"), new NonTerminal("Nominal") }), new Production(new Word[] { new NonTerminal("Nominal") }) };
            AddProduction(npRHS, "NP");

            Production[] vpRHS = { new Production(new Word[] { new NonTerminal("CV") }), new Production(new Word[] { new NonTerminal("CV"), new NonTerminal("PP") }), new Production(new Word[] { new Terminal("Verb") })};
            AddProduction(vpRHS, "VP");

            Production[] ppRHS = { new Production(new Word[] { new Terminal("Preposition"), new NonTerminal("NP") })};
            AddProduction(ppRHS, "PP");

            Production[] cnRHS = { new Production(new Word[] { new Terminal("Noun") }), new Production(new Word[] { new Terminal("Adjective"), new Terminal("Noun") }), new Production(new Word[] { new NonTerminal("Nominal"), new Terminal("Noun") }), new Production(new Word[] { new NonTerminal("Nominal"), new NonTerminal("PP") })};
            AddProduction(cnRHS, "Nominal");

            Production[] cvRHS = { new Production(new Word[] { new Terminal("Verb"), new NonTerminal("NP") })};
            AddProduction(cvRHS, "CV");

            CustomGrammarForm();
        }

        public void CustomGrammarForm()
        {
            var output =  _textReader.TextReaderFromFileAsync(_sourceString).Result.Replace("\r\n", "");

            string[] lines = output.Split(';');

            foreach (var line in lines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    int index = line.IndexOf('>');
                    string partOfSpeech = line.Substring(0, index-1).Trim();
                    var terminal  = line.Substring(index + 1).Trim();
                    string[] _terminals = terminal.Split('|');

                    var final = _terminals.Select(x => x.Trim()).ToArray();
                    
                    DictionaryBuilder(final, partOfSpeech);                  
                }
            }

            DictionaryBuilder(Pronoun.Pronouns, "Pronoun");
            DictionaryBuilder(Determiners.ArticleList, "DT");
            DictionaryBuilder(Prepositions.SingleWord, "Preposition");
            DictionaryBuilder(Prepositions.TwoWords, "Preposition");
            DictionaryBuilder(Prepositions.ThreeWords, "Preposition");
            DictionaryBuilder(Prepositions.CommonIdiomaticExpressions, "Preposition");
        }
    }
}