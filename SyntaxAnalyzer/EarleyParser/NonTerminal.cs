using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaris.NLP.SyntaxAnalyzer.EarleyParser
{
    public class NonTerminal : Word
    {
        public NonTerminal(string value) : base(value) { }

        public override bool IsTerminal => false;
    }
}
