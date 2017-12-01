using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
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

            //var list = new List<PointFeature>()
            //{
            //    new PointFeature(RegisterGroup.Lowercase, RegisterGroup.Symbols, false),
            //    new PointFeature(RegisterGroup.Digit, RegisterGroup.Digit, false),
            //    new PointFeature(RegisterGroup.Digit, RegisterGroup.Digit, false),
            //    new PointFeature(RegisterGroup.Digit, RegisterGroup.Space, true),
            //    new PointFeature(RegisterGroup.Uppercase, RegisterGroup.Space, false),
            //    new PointFeature(RegisterGroup.Uppercase, RegisterGroup.Uppercase, false),
            //    new PointFeature(RegisterGroup.Abbreviation, RegisterGroup.Space, false),
            //    new PointFeature(RegisterGroup.Lowercase, RegisterGroup.Space, true),
            //    new PointFeature(RegisterGroup.Lowercase, RegisterGroup.Uppercase, true),
            //    new PointFeature(RegisterGroup.Lowercase, RegisterGroup.Quote, true),
            //    new PointFeature(RegisterGroup.Title, RegisterGroup.Space, false),
            //    new PointFeature(RegisterGroup.Lowercase, RegisterGroup.Punctuation, false),
            //    new PointFeature(RegisterGroup.Uppercase, RegisterGroup.Punctuation, false),
            //    new PointFeature(RegisterGroup.Punctuation, RegisterGroup.Punctuation, false),
            //};

            //TrainingCenter t = new TrainingCenter();

            //var statistics = t.BindData(list);

            //double er = (double)statistics.FirstOrDefault(x => x.Type == false).Feature.Where(g => g.Previous == RegisterGroup.Uppercase).Count() / (double)statistics.FirstOrDefault(x => x.Type == false).Count;
            //double fr = (double)statistics.FirstOrDefault(x => x.Type == false).Count / (double)list.Count();
            //double rer = (double)statistics.Select(x => x.Feature.Where(g => g.Previous == RegisterGroup.Uppercase)).Count() / (double)list.Count();

            //var rt = er * fr / rer;
            string text = "Mr. Balbi told a news conference that the submarine had its whole operating system checked two days before setting sail! \"The submarine doesn't sail if that's not done. If it set off... it was because it was in condition to do so,\" he said. Relatives gathered at 2.45 the submarine's naval base on Saturday to take part in a religious ceremony and were joined by hundreds of supporters. Some have reportedly begun mourning their loved ones, fearing it is too late for them to be found alive. On Friday the country's president said an inquiry would be launched to find out the \"truth\" after a week of uncertainty and speculation.";


            IOManager manager = new ConsoleManager();

            IText context = new Text(manager.Read(text));

            ISentenceDetector detector = new DefaultSentenceDetector(context, new BaseRuleConvention());
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
