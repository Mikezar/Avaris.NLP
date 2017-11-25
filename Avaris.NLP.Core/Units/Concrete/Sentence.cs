using System;
using System.Collections.Generic;
using System.Linq;

namespace Avaris.NLP.Core.Units.Concrete
{
    public class Sentence : ISentence
    {    
        public string Source { get; set; }
        public string Normalized { get; set; }
        public ICollection<IWord> Components { get; set; }

        public int InitialPosition { get; }
        public int FinalPosition { get; }


        public int Count => Components?.Count() ?? 0;


        public Sentence(string text, int start, int end)
        {
            if (string.IsNullOrEmpty(text)) throw new NullReferenceException("text");

            InitialPosition = start;
            FinalPosition = end;
            Source = text;
        }
    }
}
