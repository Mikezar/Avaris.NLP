﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaris.NLP.SyntaxAnalyzer.SentenceDetector
{
   public  interface INaiveBayesClassifier
    {
        bool Classify();
    }
}
