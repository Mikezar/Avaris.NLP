using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaris.NLP.SyntaxAnalyzer.EarleyParser
{
    public class Item
    {
        private readonly Production _production;

        private readonly int _currentPosition;

        private readonly  StateSet _parentState;
        private const string DOT = "@";
        private int index = -1;
        private bool hasDot = false;

        public Item(Production production, StateSet state) : this(production,state, 0) { }

        public Item(Production production, StateSet state, int currentPosition)
        {
            _production = production;
            _parentState = state;
            _currentPosition = currentPosition;
        }

        public Item PreviousItem => new Item(_production, _parentState, Production.GetBeforePointerPosition());

        public Item NextItem => new Item(_production, _parentState, Production.GetAfterPointerPosition());


        public Production Production => _production;

        public int CurrentPosition => _currentPosition;

        public StateSet ParentState => _parentState;


        public override string ToString()
        {
            return _production.Words[_currentPosition].ToString();
        }

        public Word Word
        {
            get
            {
                if(IsAtEnd()) throw new InvalidOperationException();
                return Production.Words.ElementAt(CurrentPosition);
            }
        }

        public bool IsAtStart()
        {
            return _currentPosition == 0;
        }

        public bool IsAtEnd()
        {
            return _currentPosition == _production.Words.Count();
        }

    }
}
