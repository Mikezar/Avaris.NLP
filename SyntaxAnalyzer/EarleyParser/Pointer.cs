using System;

namespace Avaris.NLP.SyntaxAnalyzer.EarleyParser
{
    public sealed class Pointer
    {
        private int _fatdot = -1;

        public int FatDot
        {
            get { return _fatdot;}
            set { _fatdot = value; }
        }

        public Item Item { get; set; }

        public Pointer(int dot, Item item)
        {
            FatDot = dot;
            Item = item;
        }

        public override int GetHashCode()
        {
            return new {FatDot, Item}.GetHashCode();
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (this == obj)
                return true;

            if (obj is String)
            {
                return FatDot.Equals((String) obj);
            }
            else if (obj is Terminal)
            {
                return FatDot.Equals(((Terminal)obj).Value);
            }
       
            return false;
        }
    }
}
