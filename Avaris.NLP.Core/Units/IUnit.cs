using System.Collections.Generic;

namespace Avaris.NLP.Core.Units
{
    public interface IUnit<T>
    {
        string Source { get; set; }
        string Normalized { get; set; }
        ICollection<T> Components { get; set; }
        int Count { get; }
    }
}
