using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaris.NLP.Core.Units
{
    public interface IUnit<T>
    {
        string Source { get;}
        string Normalized { get; set; }
        IEnumerable<T> Components { get; set; }
        int Count { get; }
    }
}
