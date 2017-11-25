using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using NLog;

namespace Avaris.NLP.Core.IO
{
    public class FileReader : IFileReader
    {
        private readonly IEnumerable<string> _extensions;

        private readonly ILogger _logger;

        public FileReader(ILogger logger, IEnumerable<string> extensions)
        {
            _logger = logger;
            _extensions = extensions;
        }

        private void Validate(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new NullReferenceException($"The string {path} was null or empty");
            if (!File.Exists(path)) throw new Exception("The file doesn't exist");
            if (!CheckExtension(path)) throw new ArgumentException("path");
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

        public bool CheckExtension(string path)
        {
            return _extensions.Contains(Path.GetExtension(path));
        }
    }
}
