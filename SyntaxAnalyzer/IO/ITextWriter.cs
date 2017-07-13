using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaris.NLP.SyntaxAnalyzer.IO
{
    public interface ITextWriter
    {
        void Writer(string output);
        void Writer(IEnumerable<string> output);
        void FileWriterAsync(string output);
        void FileWriterAsync(IEnumerable<string> output);
    }
}
