using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Avaris.NLP.Core.IO
{
   public abstract class IOManager
    {
        private readonly ILogger _logger;

        private static readonly IEnumerable<string> _extensions = new List<string>() {".txt", ".doc"};

        public readonly IFileWriter FileWriter;
        public readonly IFileReader FileReader;

        public IOManager()
        {
            _logger = LogManager.GetLogger("IO"); 
            FileWriter = new FileWriter(_logger);
            FileReader = new FileReader(_logger);
        }

        public abstract void Write(string text);

        public static bool CheckExtension(string path)
        {
            return _extensions.Contains(Path.GetExtension(path));
        }
    }
}
