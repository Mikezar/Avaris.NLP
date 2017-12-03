using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Avaris.NLP.Core.IO
{
    public class FileWriter : IFileWriter
    {
        private readonly ILogger _logger;

        public FileWriter(ILogger logger)
        {
            _logger = logger;
        }

        private string CreateDirectory(string fileName)
        {
            var directory = Directory.CreateDirectory($"{AppDomain.CurrentDomain.BaseDirectory}\\Output");
            return $"{directory.FullName}\\{fileName}.txt";
        }

        private string GetFileName(string fileName) =>
            $"{fileName}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}";

        public async Task FileWriteAsync(string output, string fileName)
        {
            string filename = GetFileName(fileName);
            string path = CreateDirectory(filename);

            using (var writer = new StreamWriter(path, true, Encoding.Default))
            {
                await writer.WriteLineAsync(output);
            }

            _logger.Info($"The text was successfully written to the file {filename}.");
        }

        public async Task FileWriteAsync(IEnumerable<string> output, string fileName)
        {
            var builder = new StringBuilder();

            int counter = 1;
            foreach (var str in output)
            {
                builder.AppendLine($"{counter++}. {str}");
            }

            await FileWriteAsync(builder.ToString(), fileName);
        }

        public void FileWrite(string output, string fileName)
        {
            string filename = GetFileName(fileName);
            string path = CreateDirectory(filename);

            using (var writer = new StreamWriter(path, true, Encoding.Default))
            {
                writer.WriteLine(output);
            }

            _logger.Info($"The text was successfully written to the file {filename}.");
        }

        public void FileWrite(IEnumerable<string> output, string fileName)
        {
            var builder = new StringBuilder();

            int counter = 1;
            foreach (var str in output)
            {
                builder.AppendLine($"{counter++}. {str}");
            }

           FileWrite(builder.ToString(), fileName);
        }

        //public void ChartWriter(Recognizer recognizer, bool status)
        //{
        //    var charts = recognizer.Charts;
        //    var sentence = recognizer.Sentence;
        //    var builder = new StringBuilder();

        //    for (int i = 0; i < sentence.Length - 1; i++)
        //        builder.Append(sentence[i].ToString() + " ");

        //    builder.Append(sentence[sentence.Length - 1] + ".");

        //    string outputSentence = builder.ToString();

        //    Console.WriteLine($"\nSentence: \"{outputSentence}\"");
        //    Console.WriteLine($"Successfully recognized: {status}");
        //    Console.WriteLine("\r\n");
        //    Console.WriteLine($"Charts produced by the sentence: \"{outputSentence}\"");
        //    for (int i = 0; i < charts.Length; i++)
        //    {
        //        Console.WriteLine($"Chart {i}:");
        //        Console.WriteLine(charts[i]);
        //    }
        //}   
    }
}
