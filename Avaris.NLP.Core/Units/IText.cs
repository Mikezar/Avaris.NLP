using System.Collections.Generic;

namespace Avaris.NLP.Core.Units
{
    public interface IText : IUnit<ISentence>
    {
        IEnumerable<char> Separators { get; }
    }
}
