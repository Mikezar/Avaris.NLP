using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Avaris.NLP.MorfologyLibrary.Rules;

namespace Avaris.NLP.MorfologyLibrary.Tokenization
{
   public class Lexer : ILexer
   {
       private readonly string _sentence;
       private readonly char[] _delimiter;
       private readonly Regex _rule = new Regex(LexicalRule.RedundantPunctuation);
       private readonly char[] _default = {' ', '\r', '\n', '\t'};
       private readonly List<TokenRule> Rules = new List<TokenRule>();

        public Lexer(string sentence)
        {
            if (string.IsNullOrEmpty(sentence)) throw new ArgumentNullException(sentence);
            DictionaryBuilder();
            _sentence = sentence;
            _delimiter = _default;
        }

        public Lexer(string sentence, char[] delimiter)
        {
            if (string.IsNullOrEmpty(sentence)) throw new ArgumentNullException(sentence);
            DictionaryBuilder();
            _sentence = sentence;
            _delimiter = delimiter;
        }

       private void DictionaryBuilder()
       {
           AddRule(TokenType.Word, LexicalRule.Word);
           AddRule(TokenType.Currency, LexicalRule.Currency);
           AddRule(TokenType.Value, LexicalRule.Value);
           AddRule(TokenType.Number, LexicalRule.Number);
           AddRule(TokenType.Punctuation, LexicalRule.Punctuation);
           AddRule(TokenType.SpecialSymbol, LexicalRule.SpecialSymbols);
        }

       public IList<Token> Scanner()
       {
           var builder = new StringBuilder();
           builder.Append(_sentence);
           int index = 0;
           int offset = 0;
           while (index < _sentence.Length)
           {
               var match = _rule.Match(_sentence, index);

               if (match.Success)
               {
                   if (index == 0)
                   {
                       builder.Insert(match.Index, ' ');
                       index = match.Index + 1;
                   }
                   else
                   {
                       if (match.Index < _sentence.Length - 1)
                       {

                           if (char.IsLetter(_sentence[match.Index + 1]))
                           {
                               builder.Insert(match.Index + offset, ' ');
                               builder.Insert(match.Index + offset + 2, ' ');
                               index = match.Index + 4;
                               offset += 2;
                               continue;
                           }
                       }

                       builder.Insert(match.Index + offset, ' ');
                       index = match.Index + 2;
                   }
                   offset++;
                }
           }

           return Tokenize(builder.ToString());
       }

       public void AddRule(TokenType type, string rule)
       {
           if(string.IsNullOrEmpty(rule)) throw  new NullReferenceException(rule);

           Rules.Add(new TokenRule() {Type = type, Rule = new Regex(rule)});
       }

        public void Evaluator(IList<Token> tokens)
        {
            foreach (var token in tokens)
            {
                for (int i = 0; i < Rules.Count; i++)
                {
                    if (Rules[i].Rule.IsMatch(token.Value))
                    {
                        token.Type = Rules[i].Type;
                    }
                }

                if (token.Type == TokenType.Operator)
                {
                    token.Type = TokenType.Unknown;
                }
            }
        }

       public IList<Token> Tokenize(string formattedSentence)
       {
            return formattedSentence.Split(_delimiter).Select(x => new Token()
            {
                Value = x.ToLower().Trim()
            }).Where(x => !x.IsEmpty).ToList();
       }

        public string STreeBuilder(IList<Token> tokens)
        {
            var builder = new StringBuilder();

            builder.AppendLine($"(sentence");
            foreach (var token in tokens)
            {
                builder.AppendLine($"  ({token.Type.ToString().ToLower()} {token.Value.ToUpper()})");
            }

            builder.Append($")");

            return builder.ToString();
        }
    }
}
