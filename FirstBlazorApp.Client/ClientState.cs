using FirstBlazorApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstBlazorApp.Client
{
    public class ClientState
    {
        public List<string> SymbolsToDisplay => ListOfStockValues.Keys.ToList();
        public Dictionary<string, GraphStockValues> ListOfStockValues{ get; private set; }

        public event EventHandler StateChanged;

        public ClientState()
        {
            ListOfStockValues = new Dictionary<string, GraphStockValues>();
        }

        public void AddSymbols(string symbol)
        {
            AddStockValue(symbol);
            StateHasChanged();
        }

        public void RemoveSymbol(string symbol)
        {
            Console.WriteLine($"Removing {symbol}");
            RemoveStockValue(symbol);
            StateHasChanged();
        }

        private void StateHasChanged()
        {
            StateChanged?.Invoke(this, EventArgs.Empty);
        }

        public void AddStockValue(string symbol)
        {
            if (!ListOfStockValues.ContainsKey(symbol))
            {
                ListOfStockValues.Add(symbol, new GraphStockValues(symbol));
            }
        }

        public void RemoveStockValue(string symbol)
        {
            ListOfStockValues.Remove(symbol);
        }
        public void ClearAllStockValues()
        {
            ListOfStockValues.Clear();
        }

        public GraphStockValues GetStockValues(string symbol)
        {
            if (ListOfStockValues.TryGetValue(symbol, out var stockValues))
            {
                Console.WriteLine($"Found Stock Values for {symbol}. Found {stockValues.StockValues.Count} Values in memory");
                return stockValues;
            }

            Console.WriteLine($"Could not find any values in memory for {symbol}");

            return null;
        }
    }
}
