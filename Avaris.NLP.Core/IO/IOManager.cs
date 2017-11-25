using System.Collections.Generic;
using NLog;
using System.Text;

namespace Avaris.NLP.Core.IO
{
   public abstract class IOManager
    {
        private readonly ILogger _logger;

        private readonly IEnumerable<string> _extensions;

        public readonly IFileWriter FileWriter;
        public readonly IFileReader FileReader;

        public IOManager(IEnumerable<string> extensions = null)
        {
            _logger = LogManager.GetLogger("IO");
            _extensions = extensions ?? new List<string>() { ".txt", ".doc" };
            FileWriter = new FileWriter(_logger);
            FileReader = new FileReader(_logger, _extensions);
        }

        public abstract string Read(string text);

        public abstract void Write(string text);


        public string EncodeToUTF7(string input)
        {
            return Encoding.UTF7.GetString(Encoding.UTF7.GetBytes(input));
        }
    }
}
