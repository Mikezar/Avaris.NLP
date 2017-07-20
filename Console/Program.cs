using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using Avaris.NLP.MorfologyLibrary.Tokenization;
using Avaris.NLP.SyntaxAnalyzer;
using Avaris.NLP.SyntaxAnalyzer.EarleyParser;
using Avaris.NLP.SyntaxAnalyzer.SentenceDetector;
using Avaris.NLP.SyntaxAnalyzer.Normalization;
using Avaris.NLP.SyntaxAnalyzer.Helpers;
using Avaris.NLP.SyntaxAnalyzer.IO;

namespace Avaris.NLP.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Separately, profits at rival Bank of America were boosted by tighter US interest rate policy.Goldman posted profits of $1.83bn for the quarter, down from the $2.2bn reported in the first three months of 2017 and only slightly higher than the $1.82bn it reported for the same quarter last year.We didn't navigate the market as well as we aspire to or as well as we have in the past he said. Active management firms are also under pressure as investors switch funds away from expensive stock-pickers to passive funds that track indexes such as the S&P 500. Mr Chavez also said Goldman's own performance in commodities - a business many of its rivals have shifted away from in recent years - has been weak.";

            ITextReader reader = new ConsoleTextReader();
            var output = reader.TextReader(text);
            //Task<string> output = reader.TextReaderFromFileAsync(@"C:\Users\Mike\Desktop\TestWord.txt");
           //  ISentenceDetector detector = new SentenceDetector(new TextContext(output + "  "), new Sentence(), new Normalization());

            //string s1 = "John called Fin";
            //string s2 = "John called Mary in Moscow";

            //var sentence1 = WordHelper.SplitToWords(s1);
            //var sentence2 = WordHelper.SplitToWords(s2);
            ITextWriter write = new ConsoleTextWriter();

            //Grammar grammar = new CFGrammar(@"C:\Users\m.serduyk\Desktop\SourceGrammar.txt", reader);
            //Recognizer parser = new Recognizer(grammar);

            //bool status = parser.RecognizeSentence(sentence1);
            //write.ChartWriter(parser, status);
            //bool status2 = parser.RecognizeSentence(sentence2);
            //write.ChartWriter(parser, status2);


            //var sentences = detector.EOSDetector();

            //write.Writer(sentences);



            ILexer lexer = new Lexer(text);
            var tokens = lexer.Scanner();
            lexer.Evaluator(tokens);
            System.Console.WriteLine(lexer.STreeBuilder(tokens));


            //foreach (var token in tokens)
            //{
            //    System.Console.WriteLine($"{token.Value} ");
            //}

            //write.FileWriter(sentences);
            System.Console.ReadLine();
        }
    }
}
