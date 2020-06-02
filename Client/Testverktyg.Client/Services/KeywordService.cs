using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Testverktyg.Client.Models;

namespace Testverktyg.Client.Services
{
    class KeywordService
    {
        private const string url = "http://localhost:60485/api/Keyword";


        public async Task<List<Keyword>> GetKeywordsAsync(int keywordId, Keyword keyword)
        {
            var keywords = new List<Keyword>();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.GetAsync($"{url}/{keywordId}/{keyword}");
                string keywordString = await responseMessage.Content.ReadAsStringAsync();
                keywords = JsonConvert.DeserializeObject<List<Keyword>>(keywordString);
                return keywords;
            }
        }
    }
}
