using System;

namespace Avaris.NLP.Core.IO
{
    public class ConsoleManager : IOManager
    {
        public override void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
}
