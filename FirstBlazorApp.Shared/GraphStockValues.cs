using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBlazorApp.Shared
{
    public class GraphStockValues
    {
        public GraphStockValues(string symbol)
        {
            StockValues = new List<StockValueData>();
            Symbol = symbol;
        }
        public string Symbol { get; private set; }
        public List<StockValueData> StockValues { get; set; }

        public void AddNewValue(StockValueData value)
        {
            if(StockValues.Count == 15)
            {
                StockValues.RemoveAt(0);
            }

            StockValues.Add(value);
        }
    }
}
