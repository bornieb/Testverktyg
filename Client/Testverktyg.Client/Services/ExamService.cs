using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Testverktyg.Client.Models;

namespace Testverktyg.Client.Services
{
    class ExamService
    {
        private const string url = "http://localhost:60485/api/exam";
        private WebClient webClient = new WebClient();
        //HttpClient httpClient;

        public void PostExam(Exam exam)
        {
            var jsonQuestion = JsonConvert.SerializeObject(exam);
            var webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            var response = webClient.UploadString(url, "POST", jsonQuestion);
        }

        public static async Task<List<Exam>> GetExam()
        {
            var exams = new List<Exam>();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage responseMessage;
                responseMessage = await client.GetAsync($"{url}");
                string examString;
                examString = await responseMessage.Content.ReadAsStringAsync();
                exams = JsonConvert.DeserializeObject<List<Exam>>(examString);
                return exams;
            }
        }
    }
}
