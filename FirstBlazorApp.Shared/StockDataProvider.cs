using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FirstBlazorApp.Shared
{
    public class StockDataProvider
    {
        public string Symbol { get; private set; }
        private string _url;
        private HttpClient _httpClient;

        public StockDataProvider(string symbol)
        {
            Symbol = symbol;
            _url = $"https://sandbox.iexapis.com/v1/stock/{Symbol}/price?token=Tsk_6c7152e5bd0a47a89cf6bbf72a607bde";
            _httpClient = new HttpClient();
        }
        
        public async Task<StockValueData> GetNewValue(CancellationToken cancellationToken)
        {
            var httpResponse = await _httpClient.GetAsync(_url, cancellationToken);
            var json = await httpResponse.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<double>(json);
            Console.WriteLine($"New Value for {Symbol} : {value}");
            return new StockValueData
            {
                Date = DateTime.Now.ToString("hh:mm:ss"),
                StockValue = value
            };
        }

    }
}
