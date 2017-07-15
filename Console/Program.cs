using System;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Avaris.NLP.SyntaxAnalyzer;
using Avaris.NLP.SyntaxAnalyzer.EarleyParser;
using Avaris.NLP.SyntaxAnalyzer.SentenceDetector;
using Avaris.NLP.SyntaxAnalyzer.Normalization;
using Avaris.NLP.SyntaxAnalyzer.IO;

namespace Avaris.NLP.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "At Microsoft, basic and applied research plays a vital role in breakthrough technological innovations that empower people to achieve more. The research tradition at Microsoft was formalized in 1991 with the founding of the Microsoft Research Redmond lab. Today, the Redmond lab is at the hub of Microsoft Research’s globe-spanning organization that fosters open collaborations with partners throughout industry and academic institutions as well as Microsoft product teams. Research in the Redmond lab ranges from thought leadership in security, privacy and cryptography to foundational work in areas such as systems and networking, programming languages, human - computer interaction, human language technologies, AI and computer vision. Microsoft Research Redmond is the company’s largest research lab and each year hosts several hundred research interns and visitors from distinguished undergraduate and graduate programs around the world. People come to the Microsoft Research Redmond lab for the opportunity to work on profound computer science challenges at a scale that achieves global impact.";

            ConsoleTextReader reader = new ConsoleTextReader();
            //var output = reader.TextReader(text);
            Task<string> output = reader.TextReaderFromFileAsync(@"C:\Users\Mike\Desktop\TestWord.txt");
           // ISentenceDetector detector = new SentenceDetector(new TextContext(output.Result + "  "), new Sentence(), new Normalization());


            String[] sentence1 = {"John", "called", "an", "annoying", "Mary"};
            String[] sentence2 =  {"John", "called", "Mary", "in", "Moscow"};
            Grammar grammar = new SimpleGrammar();
            Recognizer parser = new Recognizer(grammar);
            test(sentence1, parser);
            test(sentence2, parser);
            //var sentences = detector.EOSDetector();

            //ITextWriter write = new ConsoleTextWriter();
            //write.FileWriter(sentences);
            System.Console.ReadLine();
        }

        static void test(String[] sent,Recognizer parser)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < sent.Length - 1; i++)
                builder.Append(sent[i] + " ");
            builder.Append(sent[sent.Length - 1] + ".");
            String sentence = builder.ToString();
            System.Console.WriteLine(
           "\nSentence: \"" + sentence + "\"");
            bool successful =
            parser.ParseSentence(sent);
            System.Console.WriteLine(
           "Parse Successful:" + successful);
            var charts = parser.Charts;
            System.Console.WriteLine("");
            System.Console.WriteLine(
            "Charts produced by the sentence\"" + sentence + "\"");
            for (int i = 0; i < charts.Length; i++)
            {
                System.Console.WriteLine("Chart " + i + ":");
                System.Console.WriteLine(charts[i]);
            }
        }
    }
}
