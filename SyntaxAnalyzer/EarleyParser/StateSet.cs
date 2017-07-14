using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaris.NLP.SyntaxAnalyzer.EarleyParser
{
    public class StateSet
    {
        private readonly IList<Item> _chart = new List<Item>();

        public int Count => _chart.Count;

        public void AddItem(Item item)
        {
            if(item == null) throw new ArgumentNullException("item");

            if(!_chart.Contains(item))
                _chart.Add(item);
        }


        public Item GetItem(int index)
        {
            if (index < 0 || index >= _chart.Count()) throw new IndexOutOfRangeException();

            return _chart.ElementAt(index);
        }

        //internal Item this[int index]
        //{
        //    get { return _chart[index]; }
        //}

        //private Item this[Item item]
        //{
        //    get
        //    {
        //        foreach (Item existing in _chart)
        //        {
        //            if (existing.Equals(item))
        //            {
        //                return existing;
        //            }
        //        }

        //        return null;
        //    }
        //}
    }
}
