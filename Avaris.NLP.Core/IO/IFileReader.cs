using System.Threading.Tasks;

namespace Avaris.NLP.Core.IO
{
    public interface IFileReader
    {
        string TextReadFromFile(string path);
        Task<string> TextReadFromFileAsync(string path);
    }
}
