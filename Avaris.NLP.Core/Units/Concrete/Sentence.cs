using System;
using System.Collections.Generic;
using System.Linq;

namespace Avaris.NLP.Core.Units.Concrete
{
    public class Sentence : ISentence
    {
        private readonly IEnumerable<char> _separators;

        public IEnumerable<char> Separators => _separators;

        public string Source { get; private set; }
        public string Normalized { get; set; }
        public IEnumerable<IWord> Components { get; set; }

        public int Count => Components?.Count() ?? 0;


        public Sentence(string text)
        {
            if (string.IsNullOrEmpty(text)) throw new NullReferenceException("text");

            Source = text;

            _separators = new char[] { '!', '?', '.' };
        }

        public Sentence(string text, IEnumerable<char> separators) : this(text)
        {
            _separators = separators;
        }
    }
}
