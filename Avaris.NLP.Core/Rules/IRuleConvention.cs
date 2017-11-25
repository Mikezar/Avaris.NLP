using System.Text.RegularExpressions;

namespace Avaris.NLP.Core.Rules
{
    public interface IRuleConvention
    {
        Match MatchRedundantPunctuation(string input, int index);
    }
}
