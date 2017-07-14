using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Avaris.NLP.SyntaxAnalyzer.EarleyParser
{
    public class EarleyParser
    {
        private readonly Grammar _grammar;
        private  String[] _sentence;
        private  StateSet[] _chart;

        public EarleyParser(Grammar grammar)
        {
            _grammar = grammar;
        }

        public Grammar GetGrammar()
        {
            return _grammar;
        }

        public StateSet[] GetCharts()
        {
            return _chart;
        }

        public void Init(string[] input)
        {
            if (input == null) throw new NullReferenceException();
            _sentence = input;
            _chart = new StateSet[_sentence.Length + 1];

            //Иницализация состояний
            for (int i = 0; i < _chart.Length; i++)
                _chart[i] = new StateSet();
        }

        public bool EarleyParse(string[] input)
        {
            Init(input);

            Production production = new Production(new Word[] { new NonTerminal("$"), new Pointer(),  new Terminal("S") });
            Item item = new Item(production, new StateSet(), 0);
             _chart[0].AddItem(item);


            for (int i = 0; i < _chart.Length; i++)
            {
                for (int state = 0; state < _chart[i].Count; state++)
                {

                    Item currentItem = _chart[i].GetItem(state);
                    Item nextItem = item.NextItem;

                    if (!item.IsAtEnd())
                    {
                        if (currentItem.Word is NonTerminal)
                        {
                            Predictor(currentItem, _chart[i], state);
                        }
                        else
                        {
                            Scanner(currentItem, _chart[i], i);
                        }
                    }
                    else
                    {
                        Completer(currentItem, _chart[i]);
                    }

                }
            }

            Production productionF = new Production(new Word[] { new Terminal("$"), new Terminal("S") });
            Item itemF = new Item(production, new StateSet(), input.Length);

            for (int j = 0; j < _chart[input.Length].Count; j++)
            {
                Item it = _chart[input.Length].GetItem(j);

                if (it.Equals(itemF))
                    return true;
            }

            return false;
        }

        public void Predictor(Item item, StateSet state, int parentState)
        {
            var nonTerminal = item.NextItem.Word.ToString();

            var terminals = _grammar.GetTerminals(nonTerminal);


            for (int i = 0; i < terminals.Length; i++)
            {
                var production = new Production(new Word[] {new NonTerminal(nonTerminal), terminals[i]});
                Item newItem = new Item(production.AddPointer(), state, parentState);

                _chart[parentState].AddItem(newItem);
            }
        }

        public void Scanner(Item item, StateSet state, int i)
        {
            Terminal terminal = item.Word as Terminal;

            if (_grammar.IsPartOfSpeech(terminal.Value))
            {
                Item newItem = item.NextItem;
                state.AddItem(newItem);
            }
        }

        public void Completer(Item item, StateSet state)
        {
            for (int a = 0; a < _chart[item.CurrentPosition].Count; a++)
            {
                Item it = _chart[item.CurrentPosition].GetItem(a);
                Item after = it.NextItem;

                if (after.Word.ToString() != string.Empty && item.Word.ToString().CompareTo(after) == 0)
                {
                    Item ns = new Item(new Production(new Word[] {item.Word}), state, item.CurrentPosition);

                    _chart[item.NextItem.CurrentPosition].AddItem(ns);
                }
            }
        }

        //public bool ParseSentence(String[] input)
        //{
        //    _sentence = input;
        //    if (input == null) throw new NullReferenceException();

        //    _chart = new State[input.Length + 1];

        //    //Иницализация состояний
        //     for (int i = 0; i < _chart.Length; i++)
        //           _chart [i] = new State();

        //     Production production = new Production(new Word[]{ new Terminal("@"), new Terminal("S")});
        //     Item item = new Item(production, new State());
        //     _chart[0].AddItem(item);

        //    for (int i = 0; i < _chart.Length; i++)
        //    {
        //        for (int j = 0; j < _chart[i].Count; j++)
        //        {
        //            Item currentItem = _chart[i].GetItem(j);
        //            Item nextItem = item.NextItem;

        //            if (item.IsAtEnd())
        //            {
        //                Completer(currentItem);
        //            }
        //            else if (_grammar.IsPartOfSpeech(nextItem.ToString()))
        //            {
        //                Scanner(currentItem);
        //            }
        //            else
        //            {
        //                Predictor(currentItem);
        //            }
        //        }
        //    }

        //    Production productionF = new Production(new Word[] { new Terminal("@"), new Terminal("S") });
        //    Item itemF = new Item(production, new State(), input.Length);

        //    for (int j = 0; j < _chart[input.Length].Count; j++)
        //    {
        //        Item it = _chart[input.Length].GetItem(j);

        //        if (it.Equals(itemF))
        //            return true;
        //    }

        //    return false;
        //}

        //private void Predictor(Item item)
        //{
        //    var lhs = item.NextItem;
        //    var rhs = _grammar.GetRHS(lhs.ToString());
        //    int j = item.;

        //    for (int i = 0; i < rhs.Length; i++)
        //    {
        //        State ns = new State(lhs, rhs[i].addDot(), j, j);

        //        charts[j].addState(ns);
        //    }
        //}

        //private void scanner(State s)
        //{
        //    string lhs = s.getAfterDot();
        //    RHS[] rhs = grammar.getRHS(lhs);
        //    int i = s.I;
        //    int j = s.J;

        //    for (int a = 0; a < rhs.Length; a++)
        //    {
        //        int count = -1;
        //        string[] terms = rhs[a].Terms;

        //        count = terms.Length;

        //        if (terms.Length == count && j < sentence.Length)
        //        {
        //            for (int k = 0; k < count; k++)
        //            {
        //                string term = terms[k].ToLower();
        //                string sent = sentence[j].ToLower();

        //                if (term.CompareTo(sent) == 0)
        //                {
        //                    State ns = new State(lhs, rhs[a].addDotLast(), j, j + 1);

        //                    charts[j + 1].addState(ns);
        //                }
        //            }
        //        }
        //    }
        //}

        //private void completer(State s)
        //{
        //    string lhs = s.Lhs;

        //    for (int a = 0; a < charts[s.I].size(); a++)
        //    {
        //        State st = charts[s.I].getState(a);
        //        string after = st.getAfterDot();

        //        if (after != string.Empty && lhs.CompareTo(after) == 0)
        //        {
        //            State ns = new State(st.Lhs, st.Rhs.moveDot(), st.I, s.J);

        //            charts[s.J].addState(ns);
        //        }
        //    }
        //}
    }
}
