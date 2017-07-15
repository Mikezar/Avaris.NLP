using System.Text;

namespace Avaris.NLP.SyntaxAnalyzer.EarleyParser
{
    public class Production
    {
        private readonly bool _hasDot = false;
        private readonly int _dot = -1;
        private const string DOT = "@";
        private readonly string[] _terminals;

        public Production(string[] terminals)
        {
            _terminals = terminals;

            for (int i = 0; i < _terminals.Length; i++)
            {
                if (_terminals[i].CompareTo(DOT) == 0)
                {
                    _dot = i;
                    _hasDot = true;
                    break;
                }
            }
        }

        public int Dot => _dot;

        public bool HasDot => _hasDot;

        public string[] Terminals => _terminals;

        public string GetTerminalBeforeDot()
        {
            if (_hasDot && _dot > 0)
                return _terminals[_dot - 1];

            return string.Empty;
        }

        public string GetTerminalAfterDot()
        {
            if (_hasDot && _dot < _terminals.Length - 1)
                return _terminals[_dot + 1];

            return string.Empty;
        }

        public bool IsAtStart()
        {
            if (_hasDot)
                return _dot == 0;

            return false;
        }

        public bool IsAtEnd()
        {
            if (_hasDot)
                return _dot == _terminals.Length - 1;

            return false;
        }

        public Production AddDot()
        {
            string[] t = new string[_terminals.Length + 1];

            t[0] = DOT;

            for (int i = 1; i < t.Length; i++)
                t[i] = _terminals[i - 1];

            return new Production(t);
        }

        public Production AddDotAtEnd()
        {
            string[] t = new string[_terminals.Length + 1];

            for (int i = 0; i < t.Length - 1; i++)
                t[i] = _terminals[i];

            t[t.Length - 1] = DOT;
            
            return new Production(t);
        }

        public Production MoveDot()
        {
            string[] t = new string[_terminals.Length];

            for (int i = 0; i < t.Length; i++)
            {
                if (_terminals[i].CompareTo(DOT) == 0)
                {
                    t[i] = _terminals[i + 1];
                    t[i + 1] = DOT;
                    i++;
                }

                else
                    t[i] = _terminals[i];
            }

            return new Production(t);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return this == null;

            Production production = (Production)obj;

            if (_terminals.Length != production.Terminals.Length)
                return false;

            for (int i = 0; i < _terminals.Length; i++)
                if (_terminals[i].CompareTo(production.Terminals[i]) != 0)
                    return false;

            return _dot == production.Dot;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            for (int i = 0; i < _terminals.Length; i++)
                builder.Append($"{_terminals[i]} ");

            return builder.ToString();
        }
    }
}