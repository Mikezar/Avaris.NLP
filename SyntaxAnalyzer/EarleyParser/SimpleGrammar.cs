using System;

namespace Avaris.NLP.SyntaxAnalyzer.EarleyParser
{
   public class SimpleGrammar : Grammar
    {
        public SimpleGrammar()
        {
            ProductionInit();
        }

        private void ProductionInit()
        {
            var nonTerminal1 = "S";
            var terminals1 = new[] {new Terminal("NP"),new Terminal("VP") };
            ProductionAdd(nonTerminal1, terminals1);

            var nonTerminal2 = "NP";
            var terminals2 = new[] { new Terminal("NP"), new Terminal("PP"), new Terminal("Noun") };
            ProductionAdd(nonTerminal2, terminals2);

            var nonTerminal3 = "VP";
            var terminals3 = new[] { new Terminal("Verb"), new Terminal("NP"), new Terminal("VP"), new Terminal("PP")};
            ProductionAdd(nonTerminal3, terminals3);

            var nonTerminal4 = "PP";
            var terminals4 = new[] { new Terminal("Prep"), new Terminal("NP") };
            ProductionAdd(nonTerminal4, terminals4);

            var nounNonTerminal = "Noun";
            var nounTerminals = new[] { new Terminal("John"), new Terminal("Mary"), new Terminal("Denver") };
            ProductionAdd(nounNonTerminal, nounTerminals);

            var verbNonTerminal = "Verb";
            var verbTerminals = new[] { new Terminal("called") };
            ProductionAdd(verbNonTerminal, verbTerminals);

            var prepNonTerminal = "Prep";
            var prepTerminals = new[] { new Terminal("from") };
            ProductionAdd(prepNonTerminal, prepTerminals);
        }

        private void ProductionAdd(string nonTerminal, Terminal [] terminals)
        {
            Productions.Add(nonTerminal, terminals);
        }

        private void PartOfSpeechInit()
        {
            PartOfSpeech.Add("Noun");
            PartOfSpeech.Add("Verb");
            PartOfSpeech.Add("Prep");
        }
    }
}
