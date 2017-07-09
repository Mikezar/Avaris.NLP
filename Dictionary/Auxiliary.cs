using System.Collections.Generic;

namespace Avaris.NLP.Dictionary
{
   public class Auxiliary
   {
       public List<string> AuxVerbs = new List<string>()
       {
           "be",
           "been",
           "am",
           "is",
           "are",
           "was",
           "were",
           "has",
           "have",
           "had",
           "do",
           "does",
           "did",
       };

        public List<string> ModalVerbs = new List<string>()
       {
           "can",
           "could",
           "may",
           "might",
           "must",
           "will",
           "shall",
           "would",
           "should",
           "ought",
       };

       public List<string> QuestionWords = new List<string>()
       {
           "when",
           "what",
           "where",
           "who",
           "whose",
           "which",
           "whom",
           "how",
       };

       public static List<string> Abbreviations = new List<string>()
       {
           "etc.",
           "i.e"
       };
   }
}
