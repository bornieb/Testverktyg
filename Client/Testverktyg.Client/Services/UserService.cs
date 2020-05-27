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
    public class UserService
    {
        private HttpClient httpClient;
        string url = "http://localhost:60485/api/user";

        public UserService()
        {
            httpClient = new HttpClient();
        }

        public async Task<User> GetUser(string userName, string password)
        {
            var jsonUser = await httpClient.GetStringAsync(url+$"/checkuser?userName={userName}&password={password}");
            var user = JsonConvert.DeserializeObject<User>(jsonUser);
            return user;
        }
    }
}
