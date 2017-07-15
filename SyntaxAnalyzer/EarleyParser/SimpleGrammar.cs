using System;

namespace Avaris.NLP.SyntaxAnalyzer.EarleyParser
{
   public  class SimpleGrammar : Grammar
    {
        public SimpleGrammar()
        {
            initialize();
        }

        private void initialize()
        {
            initRules();
            initPOS();
        }

        private void initRules()
        {

            Production[] sRHS = { new Production(new string[] { "NP", "VP" })};
            AddProduction(sRHS, "S");

            Production[] npRHS = { new Production(new string[] { "Pronoun"}), new Production(new string[] { "Proper-Noun" }), new Production(new string[] { "DT", "Nominal" }), new Production(new string[] { "Nominal" }) };
            AddProduction(npRHS, "NP");

            Production[] vpRHS = { new Production(new string[] { "CV" }), new Production(new string[] { "CV", "PP" }), new Production(new string[] { "Verb" })};
            AddProduction(vpRHS, "VP");

            Production[] ppRHS = { new Production(new string[] { "Preposition", "NP" })};
            AddProduction(ppRHS, "PP");

            Production[] cnRHS = { new Production(new string[] { "Noun" }), new Production(new string[] { "Adjective", "Noun" }), new Production(new string[] { "Nominal", "Noun" }), new Production(new string[] { "Nominal", "PP" })};
            AddProduction(cnRHS, "Nominal");

            Production[] cvRHS = { new Production(new string[] { "Verb", "NP" })};
            AddProduction(cvRHS, "CV");

            //Production[] sRHS = { new Production(new string[] { "NP", "VP" }) };
            //AddProduction(sRHS, "S");

            //Production[] npRHS = { new Production(new string[] { "NP", "PP"  }), new Production(new string[] { "Noun" }) };
            //AddProduction(npRHS, "NP");

            //Production[] vpRHS = { new Production(new string[] { "VP", "NP" }), new Production(new string[] { "Verb", "PP" }), new Production(new string[] { "Verb", "Noun" }), new Production(new string[] { "Verb" }) };
            //AddProduction(vpRHS, "VP");

            //Production[] ppRHS = { new Production(new string[] { "Prep", "NP" }), new Production(new string[] { "Prep" }) };
            //AddProduction(ppRHS, "PP");


            Production[] nounRHS = { new Production(new string[] { "John" }), new Production(new string[] { "Mary" }), new Production(new string[] { "Denver" }), new Production(new string[] { "Moscow" }), };
            AddProduction(nounRHS, "Noun");

            Production[] verbRHS = { new Production(new string[] { "called" }) };
            AddProduction(verbRHS, "Verb");

            Production[] adjRHS = { new Production(new string[] { "annoying" }) };
            AddProduction(adjRHS, "Adjective");

            Production[] dtRHS = { new Production(new string[] { "an" }) };
            AddProduction(dtRHS, "DT");

            Production[] pronounRHS = { new Production(new string[] { "I" }) };
            AddProduction(pronounRHS, "Pronoun");

            Production[] properNounRHS = { new Production(new string[] { "Moscow" }) };
            AddProduction(properNounRHS, "Proper-Noun");

            Production[] prepRHS = { new Production(new string[] { "from"}), new Production(new string[] { "in" }) };
            AddProduction(prepRHS, "Preposition");
        }

        private void initPOS()
        {
            AddPartOfSpeech("Noun");
            AddPartOfSpeech("Verb");
            AddPartOfSpeech("DT");
            AddPartOfSpeech("Adjective");
            AddPartOfSpeech("Pronoun");
            AddPartOfSpeech("Proper-Noun");
            AddPartOfSpeech("Preposition");
        }
    }
}