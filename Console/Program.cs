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
using Avaris.NLP.Core.IO;
using Avaris.NLP.Core.Units;
using Avaris.NLP.Core.Units.Concrete;
using Avaris.NLP.Core.Rules;

namespace Avaris.NLP.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //if (preNormalizing)
            //{
            //   _text.Source = _normalization.PreNormalizationToEOSDetection(_text.Source);
            //}


            string text = "  Connecticut  --  $  100  million  of  general obligation capital  appreciation bonds, College  Savings Plan,  1989  Series B, via  a Prudential-Bache  Capital Funding group.";
       
            IOManager manager = new ConsoleManager();

            IText context = new Text(manager.Read(text));

            ISentenceDetector detector = new SentenceDetector(context, new Normalization(), new BaseRuleConvention());
            var sentences = detector.DetectEnd();

            foreach (var sentence in sentences)
            {
                manager.Write(sentence.Source);
            }


            //Task<string> output = reader.TextReaderFromFileAsync(@"C:\Users\Mike\Desktop\TestWord.txt");
            //  ISentenceDetector detector = new SentenceDetector(new TextContext(output + "  "), new Sentence(), new Normalization());

            //string s1 = "John called Fin";
            //string s2 = "John called Mary in Moscow";

            //var sentence1 = WordHelper.SplitToWords(s1);
            //var sentence2 = WordHelper.SplitToWords(s2);
            //  ITextWriter write = new ConsoleTextWriter();

            //Grammar grammar = new CFGrammar(@"C:\Users\m.serduyk\Desktop\SourceGrammar.txt", reader);
            //Recognizer parser = new Recognizer(grammar);

            //bool status = parser.RecognizeSentence(sentence1);
            //write.ChartWriter(parser, status);
            //bool status2 = parser.RecognizeSentence(sentence2);
            //write.ChartWriter(parser, status2);


            //var sentences = detector.EOSDetector();

            //write.Writer(sentences);



            //ILexer lexer = new Lexer(text);
            //var tokens = lexer.Scanner();
            //lexer.Evaluator(tokens);
            //System.Console.WriteLine(lexer.STreeBuilder(tokens));


            //foreach (var token in tokens)
            //{
            //    System.Console.WriteLine($"{token.Value} ");
            //}

            //write.FileWriter(sentences);
            System.Console.ReadLine();
        }
    }
}
