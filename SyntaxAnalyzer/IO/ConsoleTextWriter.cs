using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
    }
}
