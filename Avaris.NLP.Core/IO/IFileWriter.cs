using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avaris.NLP.Core.IO
{
    public interface IFileWriter
    {
        void FileWrite(string output);
        void FileWrite(IEnumerable<string> output);
        Task FileWriteAsync(string output);
        Task FileWriteAsync(IEnumerable<string> output);
    }
}
