using Application.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationSource.Client
{
    public class ConfigurationSourceClient
    {
        private readonly HttpClient _client;

        public ConfigurationSourceClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<MyConfiguration> GetConfiguration()
        {
            var result = await _client.GetAsync("api/Configurations");
            var content = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<MyConfiguration>(content);
        }
    }
}
