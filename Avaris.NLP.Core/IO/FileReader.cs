using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Avaris.NLP.Core.IO
{
    public class FileReader : IFileReader
    {

        private readonly ILogger _logger;

        public FileReader(ILogger logger)
        {
            _logger = logger;
        }

        private void Validate(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new NullReferenceException($"The string {path} was null or empty");
            if (!File.Exists(path)) throw new Exception("The file doesn't exist");
            if (!IOManager.CheckExtension(path)) throw new ArgumentException("path");
        }


        public string TextReadFromFile(string path)
        {
            Validate(path);

            Char[] buffer;

            using (var reader = new StreamReader(path, Encoding.Default))
            {
                buffer = new char[(int)reader.BaseStream.Length];
                reader.Read(buffer, 0, (int)reader.BaseStream.Length);
            }
            return new string(buffer);
        }


        public async Task<string> TextReadFromFileAsync(string path)
        {
            Validate(path);

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
