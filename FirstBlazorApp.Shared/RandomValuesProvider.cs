using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FirstBlazorApp.Shared
{
    public class RandomValuesProvider
    {
        Random Random;
        public RandomValuesProvider()
        {
            Random = new Random();
        }

        public async Task<double> GetRandomDoubleAync()
        {
            await Task.Delay(200);
            return Random.NextDouble() + 1.0 * 200 - (Random.NextDouble() + 10) + (Random.NextDouble() + 20);
        }
    }
}
