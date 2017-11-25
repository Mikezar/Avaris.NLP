using System;
using System.Collections.Generic;
using System.Linq;

namespace Avaris.NLP.Core.Units.Concrete
{
    public class Text : IText
    {
        private readonly IEnumerable<char> _separators;

        public IEnumerable<char> Separators => _separators;

        public string Source { get; set; }

        public string Normalized { get; set; }

        public ICollection<ISentence> Components { get; set; }

        public int Count => Components?.Count() ?? 0;

        public Text(string text)
        {
            if (string.IsNullOrEmpty(text)) throw new ArgumentNullException("text");

            Source = text;
            Components = new List<ISentence>();
            _separators = new char[] { '!', '?', '.' };
        }

        public Text(string text, IEnumerable<char> separators) : this(text)
        {
            _separators = separators;
        }
    }
}
