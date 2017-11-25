using System.Collections.Generic;
using System.Linq;
using Avaris.NLP.Core.Rules;
using Avaris.NLP.SyntaxAnalyzer.Normalization;
using Avaris.NLP.Core.Units;
using Avaris.NLP.Core.Units.Concrete;

namespace Avaris.NLP.SyntaxAnalyzer.SentenceDetector
{
    public class SentenceDetector : ISentenceDetector
    {
        private readonly IText _text;
        private readonly INormalization _normalization;
        private readonly IRuleConvention _rule;
        private ICollection<int> _positions;

        public int CurrentPosition { get; set; }
        public int PreviousPosition { get; set; }
        public int? ReservedPosition { get; set; }

        public int SpanLength => CurrentPosition - PreviousPosition;

        public SentenceDetector(IText text, INormalization normalization, IRuleConvention rule)
        {
            _text = text;
            _normalization = normalization;
            _rule = rule;
        }

        public IEnumerable<ISentence> DetectEnd()
        {
            var positions = DetectPositions().ToArray();


            for (int i = 0; i < positions.Count(); i++)
            {
                if (i == positions.Count() - 1)
                {
                    GenerateSentence(positions[i], CurrentPosition - positions[i] + 1);
                    continue;
                }

                GenerateSentence(positions[i], positions[i + 1] - positions[i]);
            }

            return _text.Components;
        }

        public IEnumerable<int> DetectPositions()
        {
            _positions = new List<int>();

            var symbolCount = _text.Source.Count(x => _text.Separators.Contains(x));

            for (int i = 0; i < symbolCount; i++)
            {
                CurrentPosition = GetCurrentPosition(CurrentPosition);

                if (CurrentPosition == -1) break;

                SymbolAnalyzer(PreviousPosition, CurrentPosition, SpanLength);
            }

            return _positions;
        }

        private void SymbolAnalyzer(int initialPosition, int finalPosition, int spanLength)
        {
            switch (_text.Source[finalPosition])
            {
                case '!':
                case '?':
                    _positions.Add(initialPosition);
                    break;
                case '.':
                    if (RuleObserver(finalPosition))
                    {
                        if (ReservedPosition == 0)
                            _positions.Add(initialPosition);
                        else
                        {
                            _positions.Add(ReservedPosition.GetValueOrDefault());
                            ResetReservedPosition();
                        }
                    }
                    else
                    {
                        if (ReservedPosition != null && ReservedPosition == 0)
                            ReservedPosition = initialPosition;
                    }
                    break;
                default:
                    return;
            }
        }

        private void GenerateSentence(int initialPosition, int length)
        {
            _text.Components.Add(new Sentence(
                _text.Source.Substring(initialPosition, length).Trim(), initialPosition, length));
        }

        private bool RuleObserver(int index)
        {
            var match = _rule.MatchRedundantPunctuation(_text.Source, index);

            if (match.Index == index) return true;
          
            return false;
        }

        private int GetCurrentPosition(int index)
        {
            int offset = _text.Source.IndexOfAny(_text.Separators.ToArray(), index);
            if (index == 0) return offset;

            PreviousPosition = offset + 1;
            if (offset == -1) return -1;

            return _text.Source.IndexOfAny(_text.Separators.ToArray(), offset + 1);
        }

        private void ResetReservedPosition()
        {
            ReservedPosition = 0;
        }
    }
}
