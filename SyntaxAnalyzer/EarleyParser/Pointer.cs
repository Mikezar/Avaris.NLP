using System;

namespace Avaris.NLP.SyntaxAnalyzer.EarleyParser
{
    public sealed class Pointer : Word
    {
        private int _pointer = -1;

        public int Point
        {
            get { return _pointer; }
            set {_pointer = value; }
        }

        public Item Item { get; set; }

        public Pointer()
        {

        }
        public Pointer(int pointer, Item item)
        {
            Point = pointer;
            Item = item;
        }

        public override int GetHashCode()
        {
            return new {Point, Item}.GetHashCode();
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
                return Point.Equals((String) obj);
            }
            else if (obj is Terminal)
            {
                return Point.Equals(((Terminal)obj).Value);
            }
       
            return false;
        }
    }
}
