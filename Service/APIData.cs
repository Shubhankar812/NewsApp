using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Service
{
    public static class APIData
    {
        public static async Task<Root> GetNews(string headline)
        {
            var client = new HttpClient();
            var jsonData = await client.GetStringAsync("https://gnews.io/api/v4/top-headlines?&lang=en&apikey=298fb3c651b2727457e2d6cc5b35e535&category=" + headline.ToLower());
            var result = JsonConvert.DeserializeObject<Root>(jsonData);

            return result;
        }
    }
}
