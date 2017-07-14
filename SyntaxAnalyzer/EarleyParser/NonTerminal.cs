using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaris.NLP.SyntaxAnalyzer.EarleyParser
{
    public class NonTerminal : Word
    {
        public Dictionary<Production, NonTerminal> NonTerminals = new Dictionary<Production, NonTerminal>();

        private readonly string _value;

        public string Value => _value;

        public NonTerminal(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }

        public ICollection<Production> Productions => NonTerminals.Keys;

     //   public override bool IsTerminal => true;
    }
}
