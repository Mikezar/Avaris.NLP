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
using Avaris.NLP.SyntaxAnalyzer.SentenceDetector.Models;
using Newtonsoft.Json;

namespace Avaris.NLP.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IOManager manager = new ConsoleManager();

            string input = manager.FileReader.TextReadFromFile(@"C:\Users\Mike\Desktop\TestCorpus.txt");

            TrainEOSCenter trainCenter = new TrainEOSCenter();

            var statistics = trainCenter.Train(input);

            //INaiveBayesClassifier classfier = new NaiveBayesClassifier(statistics);

            //classfier.Classify(new PointAttributeGroup ("Uppercase", "Space"), EOSOptions.LaplacianSmoothing);

            //manager.FileWriter.FileWrite(JsonConvert.SerializeObject(statistics), ("Statistics"));




            //if (preNormalizing)
            //{
            //   _text.Source = _normalization.PreNormalizationToEOSDetection(_text.Source);
            //}

         
            string text = "Mr. Balbi told a news conference that the submarine had its whole operating system checked two days before setting sail! \"The submarine doesn't sail if that's not done. If it set off... it was because it was in condition to do so,\" he said. Relatives gathered at 2.45 the submarine's naval base on Saturday to take part in a religious ceremony and were joined by hundreds of supporters. Some have reportedly begun mourning their loved ones, fearing it is too late for them to be found alive. On Friday the country's president said an inquiry would be launched to find out the \"truth\" after a week of uncertainty and speculation.";


           

            IText context = new Text(manager.Read(text));

            ISentenceDetector detector = new DefaultSentenceDetector(context);
            var sentences = detector.DetectEnd();

            //foreach (var sentence in sentences)
            //{
            //    manager.Write(sentence.Source);
            //}


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
