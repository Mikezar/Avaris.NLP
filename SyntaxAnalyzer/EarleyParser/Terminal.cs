using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaris.NLP.SyntaxAnalyzer.EarleyParser
{
    public class Terminal : Word
    {
        public Terminal(string value) : base(value) { }

        public override bool IsTerminal => true;
    }
}
