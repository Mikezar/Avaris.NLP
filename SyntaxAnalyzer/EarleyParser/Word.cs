using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaris.NLP.SyntaxAnalyzer.EarleyParser
{
    public abstract class Word
    {
        public Word(string value)
        {
            Value = value;
        }

        public string Value { get; set; }

        public abstract bool IsTerminal { get; }
    }
}
