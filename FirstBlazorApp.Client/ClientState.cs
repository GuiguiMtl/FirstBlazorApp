using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstBlazorApp.Client
{
    public class ClientState
    {
        public List<string> SymbolsToDisplay { get; private set; }

        public event EventHandler StateChanged;

        public ClientState()
        {
            SymbolsToDisplay = new List<string>();
        }

        public void AddSymbols(string symbol)
        {
            SymbolsToDisplay.Add(symbol);
            StateHasChanged();
        }

        public void RemoveSymbol(string symbol)
        {
            SymbolsToDisplay.Remove(symbol);
            StateHasChanged();
        }

        private void StateHasChanged()
        {
            StateChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
