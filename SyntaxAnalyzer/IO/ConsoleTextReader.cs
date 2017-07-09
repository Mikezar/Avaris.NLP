using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Avaris.NLP.SyntaxAnalyzer.Helpers;

namespace Avaris.NLP.SyntaxAnalyzer.IO
{
    public class ConsoleTextReader : ITextReader
    {
        public string TextReader(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                return EncodeToUTF7(text);
            }
            throw new NullReferenceException($"The string {text} was null or empty");
        }

        public async Task<string> TextReaderFromFileAsync(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new NullReferenceException($"The string {path} was null or empty");
            if (!File.Exists(path)) throw new Exception("The file doesn't exist");
            if (!Extensions.CheckExtension(path))
            {
                throw new ArgumentException("path");
            }

            Char[] buffer;

            using (var reader = new StreamReader(path, Encoding.Default))
            {
                buffer = new char[(int)reader.BaseStream.Length];
                await reader.ReadAsync(buffer, 0, (int) reader.BaseStream.Length);
            }
            return new string(buffer);
        }

        public string EncodeToUTF7(string input)
        {
            return Encoding.UTF7.GetString(Encoding.UTF7.GetBytes(input));
        }
    }
}
