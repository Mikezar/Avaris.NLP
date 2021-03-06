﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaris.NLP.Core.Units
{
    public interface ISentence : IUnit<IWord>
    {
        int InitialPosition { get; }
        int FinalPosition { get; }
    }
}
