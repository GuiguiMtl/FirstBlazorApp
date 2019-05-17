using Microsoft.Extensions.Configuration;
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
        public IConfiguration Configuration { get; }

        private string _url;
        private HttpClient _httpClient;

        public StockDataProvider(string symbol, IConfiguration configuration)
        {
            Symbol = symbol;
            Configuration = configuration;
            _url = Configuration["stockValueUrl"].Replace("{StockValues.Symbol}", Symbol);
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
