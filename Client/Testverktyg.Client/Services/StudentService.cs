using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Testverktyg.Client.Models;
using Testverktyg.Client.ViewModels;

//using Windows.Web.Http;
//using Windows.Web.Http;

namespace Testverktyg.Client.Services
{
    class StudentService
    {
        private const string url = "http://localhost:60485/api/Student";
        //private WebClient webClient = new WebClient();
        //ObservableCollection<Question> ListOfQuestions = new ObservableCollection<Question>();
        //HttpClient httpClient = new HttpClient();

        public async Task<Student> GetUserAsync(int userId)
        {
            ////Serializera till string
            //var jsonQuestion = JsonConvert.SerializeObject(userId);
            ////Httpscontent
            //HttpContent httpContent = new StringContent(jsonQuestion);
            ////Format
            //httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            ////HTTP Request
            //HttpResponseMessage message = await httpClient.PostAsync($"{url}", httpContent);

            ////Objectet i Json format
            //var jsStudent = await message.Content.ReadAsStringAsync();

            ////Deserialiserar
            //var student = JsonConvert.DeserializeObject<Student>(jsStudent);

            ////retunerar Student
            //return student;

            //Mickes
            //var student = new List<Student>();
            using (HttpClient httpClient = new HttpClient())
            {

                HttpResponseMessage responseMessage = await httpClient.GetAsync($"{url}/{userId}");
                string jsStudent = await responseMessage.Content.ReadAsStringAsync();
                var student = JsonConvert.DeserializeObject<Student>(jsStudent);

                return student;
            }

        }

    }
}
