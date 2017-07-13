using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaris.NLP.SyntaxAnalyzer.EarleyParser
{
    public class Production
    {

        private readonly Word[] _words;


        private bool HasDot = false;


        public Production(Word[] words)
        {
            _words = words;
        }

        public Word[] Words => _words;


    }
}
