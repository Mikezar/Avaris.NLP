using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaris.NLP.SyntaxAnalyzer.EarleyParser
{
    public abstract class Grammar
    {
        public Dictionary<NonTerminal, Terminal[]> Productions;
        public List<string> PartOfSpeech;

        protected Grammar()
        {
            Productions = new Dictionary<NonTerminal, Terminal[]>();
            PartOfSpeech = new List<string>();
        }

        public Terminal[] GetTerminals(NonTerminal lhs)
        {
            Terminal[] rhs = null;
            if (Productions.ContainsKey(lhs))
            {
                foreach (KeyValuePair<NonTerminal, Terminal[]> kvp in Productions)
                {
                    if (kvp.Key == lhs)
                    {
                        rhs = kvp.Value;
                        break;
                    }
                }
            }
            return rhs;
        }

        public bool IsPartOfSpeech(string key)
        {
            return PartOfSpeech.Contains(key);
        }
    }
}
