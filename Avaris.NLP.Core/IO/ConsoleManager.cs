using System;
using System.Collections.Generic;

namespace Avaris.NLP.Core.IO
{
    public class ConsoleManager : IOManager
    {
        public ConsoleManager(IEnumerable<string> extensions = null) : base(extensions){ }

        public override string Read(string text)
        {
            return EncodeToUTF7(text);
        }

        public override void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
}
