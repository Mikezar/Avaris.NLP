using System;
using System.Collections.Generic;

namespace Avaris.NLP.SyntaxAnalyzer.EarleyParser
{
   public abstract class Grammar
    {
        private Dictionary<Production[], string> Productions;
        private IList<string> PartOfSpeech;

        public Grammar()
        {
            Productions = new Dictionary<Production[], string>();
            PartOfSpeech = new List<string>();
        }

        public virtual void AddProduction(Production[] production, string nonTerminal)
        {
            if (production == null) throw new ArgumentNullException("production");
            if (string.IsNullOrEmpty(nonTerminal)) throw new NullReferenceException();

            Productions.Add(production, nonTerminal);
        }


        public virtual Production GetStartProduction()
        {
            return new Production(new string[] { "@", "S" });
        }

        public virtual Production GetFinalProduction()
        {
            return new Production(new string[] { "S", "@" });
        }

        public virtual void AddPartOfSpeech(string partOfSpeech)
        {
            if (string.IsNullOrEmpty(partOfSpeech)) throw new NullReferenceException();

            PartOfSpeech.Add(partOfSpeech);
        }

        public Production[] GetTerminals(string nonTerminal)
        {
            Production[] terminals = null;

            if (Productions.ContainsValue(nonTerminal))
            {
                foreach (var _keyValuePair in Productions)
                {
                    if (_keyValuePair.Value == nonTerminal)
                    {
                        terminals = _keyValuePair.Key;
                        break;
                    }
                }
            }

            return terminals;
        }

        public bool IsPartOfSpeech(string word)
        {
            return PartOfSpeech.Contains(word);
        }
    }
}
