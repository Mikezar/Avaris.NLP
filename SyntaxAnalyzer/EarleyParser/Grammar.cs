using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaris.NLP.SyntaxAnalyzer.EarleyParser
{
    public abstract class Grammar
    {
        public Dictionary<string, Terminal[]> Productions;
        public List<string> PartOfSpeech;

        protected Grammar()
        {
            Productions = new Dictionary<string, Terminal[]>();
            PartOfSpeech = new List<string>();
        }

        public Terminal[] GetTerminals(string lhs)
        {
            Terminal[] rhs = null;
            if (Productions.ContainsKey(lhs))
            {
                foreach (KeyValuePair<string, Terminal[]> kvp in Productions)
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
