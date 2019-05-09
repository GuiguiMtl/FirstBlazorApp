using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBlazorApp.Shared
{
    public class StockData
    {
        public string Symbol { get; set; }
        public List<double> StockValue { get; set; }
    }
}
