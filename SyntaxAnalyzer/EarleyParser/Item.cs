using System.Collections.Generic;

namespace Avaris.NLP.SyntaxAnalyzer.EarleyParser
{
   public class Item
    {
        private readonly int _currentPosition;
        private readonly int _index;
        private readonly string _nonTerminal;
        private readonly Production _terminal;

        public Item(string nonTerminal, Production terminal, int currentPosition, int index)
        {
            _nonTerminal = nonTerminal;
            _terminal = terminal;
            _currentPosition = currentPosition;
            _index = index;
        }

        public int CurrentPosition => _currentPosition;

        public int Index => _index;

        public string NonTerminal => _nonTerminal;

        public Production Terminal => _terminal;

        public Word NextItem => _terminal.GetTerminalAfterDot();

        public Word PreviousItem => _terminal.GetTerminalBeforeDot();


        public bool IsAtEnd => _terminal.IsAtEnd();

        public override bool Equals(object obj)
        {
            if (obj == null)
                return this == null;

            Item item = (Item)obj;
            bool part1 = _nonTerminal.CompareTo(item.NonTerminal) == 0;
            bool part2 = _terminal.Equals(item.Terminal);

            return part1 && part2 && _currentPosition == item.CurrentPosition && _index == item.Index;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"{_nonTerminal} -> {_terminal.ToString()} ({_currentPosition}) ({_index})";
        }
    }
}