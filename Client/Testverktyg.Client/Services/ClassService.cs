using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Testverktyg.Client.Models;

namespace Testverktyg.Client.Services
{
    public class ClassService
    {
        private const string url = "http://localhost:60485/api/class";
        HttpClient httpClient;
        public ClassService()
        {
            httpClient = new HttpClient();
        }
        public async Task<ObservableCollection<Class>> GetClassesAsync()
        {
            var jsonClasses = await httpClient.GetStringAsync(url);
            var classes = JsonConvert.DeserializeObject<ObservableCollection<Class>>(jsonClasses);
            return classes;
        }
    }
}
