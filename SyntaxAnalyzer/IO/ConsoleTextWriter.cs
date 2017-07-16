using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Avaris.NLP.SyntaxAnalyzer.EarleyParser;
using System.Threading.Tasks;

namespace Avaris.NLP.SyntaxAnalyzer.IO
{
   public class ConsoleTextWriter : ITextWriter
    {
        public void Writer(string output)
        {
            Console.WriteLine(output);
        }

        public void Writer(IEnumerable<string> output)
        {
          var builder = new StringBuilder();
          
            foreach(var t in output)
            {
                builder.AppendLine(t);
            }

            Console.WriteLine(builder.ToString());
        }

        public async void FileWriterAsync(string output)
        {
            var date = DateTime.Today;
            string filename = $"AvarisOutput_{date.Day}_{date.Month}_{date.Year}";
            var directory = Directory.CreateDirectory($"{AppDomain.CurrentDomain.BaseDirectory}\\Output");
            string path = $"{directory.FullName}\\{filename}.txt";
            
            using (var writer = new StreamWriter(path, true, Encoding.Default))
            {
                await writer.WriteLineAsync(output);
            }

            Console.WriteLine($"The text was successfully written to the file {filename}.");
        }

        public void FileWriterAsync(IEnumerable<string> output)
        {
            var builder = new StringBuilder();

            int counter = 1;
            foreach (var t in output)
            {
                builder.AppendLine($"{counter++}. {t}");
            }

            FileWriterAsync(builder.ToString());
        }

        public void ChartWriter(Recognizer recognizer, bool status)
        {
            var charts = recognizer.Charts;
            var sentence = recognizer.Sentence;
            var builder = new StringBuilder();

            for (int i = 0; i < sentence.Length - 1; i++)
                builder.Append(sentence[i].ToString() + " ");

            builder.Append(sentence[sentence.Length - 1] + ".");

            string outputSentence = builder.ToString();

            Console.WriteLine($"\nSentence: \"{outputSentence}\"");
            Console.WriteLine($"Successfully recognized: {status}");
            Console.WriteLine("\r\n");
            Console.WriteLine($"Charts produced by the sentence: \"{outputSentence}\"");
            for (int i = 0; i < charts.Length; i++)
            {
                Console.WriteLine($"Chart {i}:");
                Console.WriteLine(charts[i]);
            }
        }
    }
}
