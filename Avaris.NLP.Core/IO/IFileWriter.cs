using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avaris.NLP.Core.IO
{
    public interface IFileWriter
    {
        void FileWrite(string output, string fileName);
        void FileWrite(IEnumerable<string> output, string fileName);
        Task FileWriteAsync(string output, string fileName);
        Task FileWriteAsync(IEnumerable<string> output, string fileName);
    }
}
