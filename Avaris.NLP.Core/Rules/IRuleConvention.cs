using System.Text.RegularExpressions;
using Avaris.NLP.Core.Models;

namespace Avaris.NLP.Core.Rules
{
    public interface IRuleConvention
    {
        Match MatchRedundantPunctuation(string input, int index);
    }
}
