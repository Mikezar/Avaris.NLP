using System;

namespace Avaris.NLP.SyntaxAnalyzer.EarleyParser
{
    public class SimpleGrammar : Grammar
    {
        private readonly string _sourceString;

        public SimpleGrammar()
        {
            PartOfSpeechInit();
            ProductionInit();
        }

        public SimpleGrammar(string sourceString)
        {
            if (string.IsNullOrEmpty(sourceString)) throw new NullReferenceException(sourceString);
            _sourceString = sourceString;

            PartOfSpeechInit();
            ProductionInit();
        }

        private void PartOfSpeechInit()
        {
            AddPartOfSpeech("Noun");
            AddPartOfSpeech("Verb");
            AddPartOfSpeech("DT");
            AddPartOfSpeech("Adjective");
            AddPartOfSpeech("Pronoun");
            AddPartOfSpeech("Proper-Noun");
            AddPartOfSpeech("Preposition");
        }

        private void ProductionInit()
        {

            Production[] sRHS = { new Production(new Word[] { new NonTerminal("NP"), new NonTerminal("VP") })};
            AddProduction(sRHS, "S");

            Production[] npRHS = { new Production(new Word[] { new NonTerminal("Pronoun")}), new Production(new Word[] { new NonTerminal("Proper-Noun") }), new Production(new Word[] { new NonTerminal("DT"), new NonTerminal("Nominal") }), new Production(new Word[] { new NonTerminal("Nominal") }) };
            AddProduction(npRHS, "NP");

            Production[] vpRHS = { new Production(new Word[] { new NonTerminal("CV") }), new Production(new Word[] { new NonTerminal("CV"), new NonTerminal("PP") }), new Production(new Word[] { new NonTerminal("Verb") })};
            AddProduction(vpRHS, "VP");

            Production[] ppRHS = { new Production(new Word[] { new NonTerminal("Preposition"), new NonTerminal("NP") })};
            AddProduction(ppRHS, "PP");

            Production[] cnRHS = { new Production(new Word[] { new NonTerminal("Noun") }), new Production(new Word[] { new NonTerminal("Adjective"), new NonTerminal("Noun") }), new Production(new Word[] { new NonTerminal("Nominal"), new NonTerminal("Noun") }), new Production(new Word[] { new NonTerminal("Nominal"), new NonTerminal("PP") })};
            AddProduction(cnRHS, "Nominal");

            Production[] cvRHS = { new Production(new Word[] { new NonTerminal("Verb"), new NonTerminal("NP") })};
            AddProduction(cvRHS, "CV");

            Production[] nounRHS = { new Production(new Word[] { new Terminal("John") }), new Production(new Word[] { new Terminal("Mary") }), new Production(new Word[] { new Terminal("Denver") })};
            AddProduction(nounRHS, "Noun");

            Production[] verbRHS = { new Production(new Word[] { new Terminal("called") }) };
            AddProduction(verbRHS, "Verb");

            Production[] adjRHS = { new Production(new Word[] { new Terminal("annoying") }) };
            AddProduction(adjRHS, "Adjective");

            Production[] dtRHS = { new Production(new Word[] { new Terminal("an") }) };
            AddProduction(dtRHS, "DT");

            Production[] pronounRHS = { new Production(new Word[] { new Terminal("I") }) };
            AddProduction(pronounRHS, "Pronoun");

            Production[] properNounRHS = { new Production(new Word[] { new Terminal("Moscow") }) };
            AddProduction(properNounRHS, "Proper-Noun");

            Production[] prepRHS = { new Production(new Word[] { new Terminal("from")}), new Production(new Word[] { new Terminal("in") }) };
            AddProduction(prepRHS, "Preposition");
        }
    }
}