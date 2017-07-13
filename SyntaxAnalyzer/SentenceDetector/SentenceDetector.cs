using System.Collections.Generic;
using System.Linq;
using Avaris.NLP.SyntaxAnalyzer.Normalization;

namespace Avaris.NLP.SyntaxAnalyzer.SentenceDetector
{
    public class SentenceDetector : ISentenceDetector
    {
        private readonly IText _text;
        private readonly ISentence _sentence;
        private readonly INormalization _normalization;

        public int CurrentPosition { get; set; }
        public int PreviousPosition { get; set; }
        public int? ReservedPosition { get; set; }

        public int SpanLength => CurrentPosition - PreviousPosition;

        public SentenceDetector(IText text, ISentence sentence, INormalization normalization)
        {
            _text = text;
            _sentence = sentence;
            _normalization = normalization;
        }

        public IEnumerable<string> EOSDetector(bool preNormalizing)
        {
            if (preNormalizing)
            {
               _text.OriginalText = _normalization.PreNormalizationToEOSDetection(_text.OriginalText);
            }

                var symbolCount = _text.OriginalText.Count(x => _sentence.GetSeparators().Contains(x));

                for (int i = 0; i < symbolCount; i++)
                {
                    CurrentPosition = GetCurrentPosition(CurrentPosition);

                    if (CurrentPosition == -1) break;
                    
                    SymbolAnalyzer(PreviousPosition, CurrentPosition, SpanLength);
                }

            _text.Sentence = _sentence;
            return _sentence.GetSentences();
        }

        public void SymbolAnalyzer(int initialPosition, int finalPosition, int spanLength)
        {
            switch (_text.OriginalText[finalPosition])
            {
                case '!':
                case '?':
                    _sentence.AddSubstring(_text.OriginalText.Substring(initialPosition, spanLength + 1));
                    break;
                case '.':
                    if (RuleObserver(finalPosition))
                    {
                        if (ReservedPosition == 0)
                        {
                            _sentence.AddSubstring(_text.OriginalText.Substring(initialPosition, spanLength + 1).Trim());
                        }
                        else
                        {
                            _sentence.AddSubstring(_text.OriginalText.Substring(ReservedPosition.GetValueOrDefault(), CurrentPosition - ReservedPosition.GetValueOrDefault() + 1).Trim());
                            ResetReservedPosition();
                        }
                    }
                    else
                    {
                        if (ReservedPosition != null)
                        {
                            ReservedPosition = initialPosition;
                        }
                    }
                    break;
                default:
                    return;
            }
        }

        public bool RuleObserver(int index)
        {
            if (char.IsWhiteSpace(_text.OriginalText[index + 1]) && char.IsLower(_text.OriginalText[index - 1]))
            {
                if (char.IsLower(_text.OriginalText[index - 2]) && !(char.IsDigit(_text.OriginalText[index + 1]) || char.IsDigit(_text.OriginalText[index + 2])))  return true;

                return false;
            }
            else if (char.IsUpper(_text.OriginalText[index + 1]) && char.IsLower(_text.OriginalText[index - 1])) return true;

            return false;
        }

        public int GetCurrentPosition(int index)
        {
            int offset = _text.OriginalText.IndexOfAny(_sentence.GetSeparators(), index);
            if (index == 0) return offset;

            PreviousPosition = offset + 1;
            if (offset == -1) return -1;

            return _text.OriginalText.IndexOfAny(_sentence.GetSeparators(), offset + 1);
        }

        private void ResetReservedPosition()
        {
            ReservedPosition = 0;
        }
    }
}
