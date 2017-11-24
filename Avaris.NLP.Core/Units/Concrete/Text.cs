using System;
using System.Collections.Generic;
using System.Linq;

namespace Avaris.NLP.Core.Units.Concrete
{
    public class Text : IText
    {
        public string Source { get; private set; }

        public string Normalized { get; set; }

        public IEnumerable<ISentence> Components { get; set; }

        public int Count => Components?.Count() ?? 0;

        public Text(string text)
        {
            if (string.IsNullOrEmpty(text)) throw new ArgumentNullException("text");
      
            Source = text;
        }
    }
}
