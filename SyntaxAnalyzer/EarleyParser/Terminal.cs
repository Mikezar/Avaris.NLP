using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaris.NLP.SyntaxAnalyzer.EarleyParser
{
   public class Terminal : Word
    {
        public Dictionary<string, Terminal> Terminals = new Dictionary<string, Terminal>();

        private readonly string _value;

        public string Value => _value;

        public Terminal(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }

        public int Count()
        {
            return Terminals.Count;
        }

      //  public override bool IsTerminal => false;


        //public NonTerminal(String[] t)
        //{
        //    terms = t;
        //    for (int i = 0; i < terms.Length; i++)
        //    {
        //        if (terms[i] == DOT)
        //        {
        //            dot = i;
        //            hasDot = true;
        //            break;
        //        }
        //    }
        //}



        //public bool HasDot()
        //{
        //    return hasDot;
        //}


        //public NonTerminal AddDot()
        //{
        //    String[] t = new String[terms.Length + 1];
        //    t[0] = DOT;
        //    for (int i = 1; i < t.Length; i++)
        //        t[i] = terms[i - 1];
        //    return new NonTerminal(t);
        //}


        //public NonTerminal AddDotLast()
        //{
        //    String[] t = new String[terms.Length + 1];
        //    for (int i = 0; i < t.Length - 1; i++)
        //        t[i] = terms[i];
        //    t[t.Length - 1] = DOT;
        //    return new NonTerminal(t);
        //}


        //public NonTerminal MoveDot()
        //{
        //    String[] t = new String[terms.Length];
        //    for (int i = 0; i < t.Length; i++)
        //    {
        //        if (terms[i] == DOT)
        //        {
        //            t[i] = terms[i + 1];
        //            t[i + 1] = DOT;
        //            i++;
        //        }
        //        else
        //            t[i] = terms[i];
        //    }
        //    return new NonTerminal(t);
        //}
    }
}
