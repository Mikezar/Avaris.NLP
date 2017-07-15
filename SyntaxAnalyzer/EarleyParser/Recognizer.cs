using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Avaris.NLP.SyntaxAnalyzer.EarleyParser
{
    public class Recognizer
    {
        private string[] _sentence;
        private readonly Grammar _grammar;
        private StateSet[] _charts;

        public Recognizer(Grammar grammar)
        {
            _grammar = grammar;
        }

        public StateSet[] Charts => _charts;

        private void Init(string[] sentence)
        {
            _sentence = sentence;

            _charts = new StateSet[sentence.Length + 1];

            for (int i = 0; i < _charts.Length; i++)
                _charts[i] = new StateSet();
        }

        public bool ParseSentence(string[] sentence)
        {
            Init(sentence);

            Item initial = new Item("$", _grammar.GetStartProduction(), 0, 0);

            _charts[0].AddItem(initial);

            for (int i = 0; i < _charts.Length; i++)
            {
                for (int j = 0; j < _charts[i].Count; j++)
                {
                    Item item = _charts[i].GetItem(j);
                    string nextTerminal = item.NextItem;

                    if (item.IsAtEnd)
                    {
                        Completer(item);
                    }
                    else if (_grammar.IsPartOfSpeech(nextTerminal))
                    {
                        Scanner(item);
                    }
                    else
                    {
                        Predictor(item);
                    }
                }
            }

            Item finish = new Item("$", _grammar.GetFinalProduction(), 0, sentence.Length);

            for (int j = 0; j < _charts[sentence.Length].Count; j++)
            {
                Item state = _charts[sentence.Length].GetItem(j);

                if (state.Equals(finish))
                    return true;
            }

            return false;
        }

        private void Predictor(Item item)
        {
            string nonTerminal = item.NextItem;
            Production[] productions = _grammar.GetTerminals(nonTerminal);

            for (int i = 0; i < productions.Length; i++)
            {
                Item newItem = new Item(nonTerminal, productions[i].AddDot(), item.Index, item.Index);

                _charts[item.Index].AddItem(newItem);
            }
        }

        private void Scanner(Item item)
        {
            string nonTerminal = item.NextItem;
            Production[] productions = _grammar.GetTerminals(nonTerminal);

            for (int a = 0; a < productions.Length; a++)
            {
                int count = -1;
                string[] terms = productions[a].Terminals;

                count = terms.Length;

                if (terms.Length == count && item.Index < _sentence.Length)
                {
                    for (int k = 0; k < count; k++)
                    {
                        string term = terms[k].ToLower();
                        string sent = _sentence[item.Index].ToLower();

                        if (term.CompareTo(sent) == 0)
                        {
                            Item newItem = new Item(nonTerminal, productions[a].AddDotAtEnd(), item.Index, item.Index + 1);

                            _charts[item.Index + 1].AddItem(newItem);
                        }
                    }
                }
            }
        }

        private void Completer(Item item)
        {
            string nonTerminal = item.NonTerminal;

            for (int a = 0; a < _charts[item.CurrentPosition].Count; a++)
            {
                Item it = _charts[item.CurrentPosition].GetItem(a);
                string nextTerminal = it.NextItem;

                if (nextTerminal != string.Empty && nonTerminal.CompareTo(nextTerminal) == 0)
                {
                    Item newTerm = new Item(it.NonTerminal, it.Terminal.MoveDot(), it.CurrentPosition, item.Index);

                    _charts[item.Index].AddItem(newTerm);
                }
            }
        }
    }
}
