using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SyncSoccerData.Clients
{
    public class ApiFootballBaseClient : IApiFootballBaseClient
    {
        public async Task<T> GetAsync<T>(string url)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "api-football-v1.p.rapidapi.com");
            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "ea52f2423emsh6d54b6bd79841a1p1f7a4ejsn1922d7f49e50");

            var result = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}
