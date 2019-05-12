using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBlazorApp.Shared
{
    public class Stock
    {
        public string Symbol { get; set; }
        public List<StockValueData> StockValues { get; set; }
    }

    public class StockValueData
    {
        public string Date { get; set; }
        public double StockValue { get; set; }
    }
}
