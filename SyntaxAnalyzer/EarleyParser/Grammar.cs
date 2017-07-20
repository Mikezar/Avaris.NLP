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
            return new Production(new Word[] { new NonTerminal("@"),new NonTerminal("S") });
        }

        public virtual Production GetFinalProduction()
        {
            return new Production(new Word[] { new NonTerminal("S"), new NonTerminal("@") });
        }

        public virtual void AddPartOfSpeech(string partOfSpeech)
        {
            if (string.IsNullOrEmpty(partOfSpeech)) throw new NullReferenceException();

            PartOfSpeech.Add(partOfSpeech);
        }

        public virtual void DictionaryBuilder(string [] words, string partOfSpeech)
        {
            if(words.Length == 0) throw new ArgumentException("words");
            if(string.IsNullOrEmpty(partOfSpeech)) throw new ArgumentNullException("partOfSpeech");

            if(!PartOfSpeech.Contains(partOfSpeech)) throw new Exception($"You can't initialize dictionary with {partOfSpeech} as part of speech.");
               
            Production[] productionWords = new Production[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                productionWords[i] = new Production(new Word[] {new Terminal(words[i]) });
            }

            Productions.Add(productionWords, partOfSpeech);
        }

        public virtual void RegisterPartOfSpeech()
        {
                AddPartOfSpeech("Noun");
                AddPartOfSpeech("Verb");
                AddPartOfSpeech("DT");
                AddPartOfSpeech("Adjective");
                AddPartOfSpeech("Pronoun");
                AddPartOfSpeech("Proper-Noun");
                AddPartOfSpeech("Preposition");
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
