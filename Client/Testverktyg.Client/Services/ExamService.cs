using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Testverktyg.Client.Models;
using Windows.UI.Popups;
using Testverktyg.Client.ViewModels;

namespace Testverktyg.Client.Services
{
    class ExamService
    {
        private const string url = "http://localhost:60485/api/exam";
        private WebClient webClient = new WebClient();
        HttpClient httpClient;

        public ExamService()
        {
            httpClient = new HttpClient();
        }

        public async Task PostExam(Exam exam)
        {
            //var jsonExam1 = JsonConvert.SerializeObject(exam);
            //var webClient = new WebClient();
            //webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            //var response = webClient.UploadString(url, "POST", jsonExam1);

            var jsonExam = JsonConvert.SerializeObject(exam);
            HttpContent httpContent = new StringContent(jsonExam);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var jsonExamDB = await httpClient.PostAsync(url, httpContent);


            //OUTPUT FÖR ATT KOLLA JSON
            //MessageDialog msg = new MessageDialog(jsonExam1);
            //await msg.ShowAsync();
            //MessageDialog msg1 = new MessageDialog(response);
            //await msg1.ShowAsync();
            MessageDialog msg2 = new MessageDialog(jsonExam);
            await msg2.ShowAsync();
            MessageDialog msg3 = new MessageDialog(jsonExamDB.ToString());
            await msg3.ShowAsync();
        }

        public static async Task<List<Exam>> GetExamAsync()
        {
            var exams = new List<Exam>();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.GetAsync($"{url}");
                string examString = await responseMessage.Content.ReadAsStringAsync();
                exams = JsonConvert.DeserializeObject<List<Exam>>(examString);
                return exams;
            }
        }

        //public static async Task<List<Question>> GetExamQuestionsAsync()
        //{
        //    var questionExam = new List<Question>();
        //    using (HttpClient client = new HttpClient())
        //    {
        //        string convertString = JsonConvert.SerializeObject(TakeExamViewModel.Instance.Questions);
        //        HttpContent content = new StringContent(convertString);
        //        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        //        HttpResponseMessage responseMessage = await client.GetAsync($"{url}/5");
        //        string questionString = await responseMessage.Content.ReadAsStringAsync();
        //        questionExam = JsonConvert.DeserializeObject<List<Question>>(questionString);
        //        return questionExam;
        //    }
        //}
    }
}
