using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avaris.NLP.SyntaxAnalyzer.EarleyParser
{
   public  class StateSet
    {
        private IList<Item> _chart = new List<Item>();

        public void AddItem(Item item)
        {
            if (item == null) throw new ArgumentNullException("item");

            if (!_chart.Contains(item))
                _chart.Add(item);
        }

        public Item GetItem(int index)
        {
            if (index < 0 || index >= _chart.Count) return null;

            return _chart[index];
        }

        public int Count => _chart.Count;

        public override string ToString()
        {
            var builder = new StringBuilder();

            for (int i = 0; i < _chart.Count; i++)
                builder.AppendLine(_chart[i].ToString());

            return builder.ToString();
        }
    }
}
