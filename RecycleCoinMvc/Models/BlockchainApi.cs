using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace RecycleCoinMvc.Models
{
    public class BlockchainApi
    {
        private static Uri BaseAddress { get; set; }
        private readonly HttpClient _httpClient;

        public BlockchainApi()
        {
            _httpClient = new HttpClient();
            BaseAddress = new Uri("http://localhost:5000");
            _httpClient.BaseAddress = BaseAddress;
            
        }


        public dynamic Post(string Url,List<JProperty> content)
        {
            
            var postEvent = _httpClient.PostAsync(Url,new StringContent(new JObject(content).ToString(), System.Text.Encoding.UTF8, "application/json"));
            postEvent.Result.EnsureSuccessStatusCode();
            var response = postEvent.Result.Content.ReadAsStringAsync().Result;
            dynamic jResponse = JsonConvert.DeserializeObject(response);
            return jResponse;
        }

        public dynamic Get(string Url)
        {
            var getEvent = _httpClient.GetAsync(Url);
            var response = getEvent.Result.Content.ReadAsStringAsync().Result;
            dynamic jResponse = JsonConvert.DeserializeObject(response);
            return jResponse; 
        }



    }
}