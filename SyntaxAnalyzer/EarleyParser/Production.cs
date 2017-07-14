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

        public Pointer Pointer;

        private bool _hasDot;

        public Production(Word[] words)
        {
            _words = words;

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] is Pointer)
                {
                    Pointer = words[i] as Pointer;
                    _hasDot = true;
                    Pointer.Point = i;
                    break;
                }
            }

        }

        public Production AddPointer()
        {
           var words = new Word[Words.Length + 1];

            words[0] = new Pointer();

            for (int i = 1; i < words.Length; i++)
                words[i] = Words[i - 1];

            return new Production(words);
        }

        public int GetBeforePointerPosition()
        {
            if (_hasDot && Pointer.Point > 0)
                return Pointer.Point - 1;

            return 0;
        }

        public int GetAfterPointerPosition()
        {
            if (_hasDot && Pointer.Point < Words.Length - 1)
                return Pointer.Point + 1;

            return 0;
        }


        public Word[] Words => _words;

    }
}
