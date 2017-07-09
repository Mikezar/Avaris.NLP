using System.Threading.Tasks;

namespace Avaris.NLP.SyntaxAnalyzer.IO
{
    public interface ITextReader
    {
        string TextReader(string text);
        Task<string> TextReaderFromFileAsync(string path);
        string EncodeToUTF7(string input);
    }
}
