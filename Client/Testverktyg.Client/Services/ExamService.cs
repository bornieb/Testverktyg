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
        QuestionService service = new QuestionService();

        public ExamService()
        {
            httpClient = new HttpClient();
        }

        public async Task PostExam(Exam exam, int userId)
        {
            var cUrl = "http://localhost:60485/api/exam/userexam/" + userId;
            var jsonExam = JsonConvert.SerializeObject(exam);
            HttpContent httpContent = new StringContent(jsonExam);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var jsonExamDB = await httpClient.PostAsync(cUrl, httpContent);
        }

        public async Task PostTakenExam(Exam exam, int userId)
        {
            foreach (var question in exam.Questions) 
            {
                question.QuestionId = 0;
                question.Keywords.Clear();

                foreach (var alternative in question.Alternatives)
                {
                    alternative.AlternativeId = 0;
                    alternative.QuestionId = 0;
                }

                var newQuestion = service.AddQuestion(question);
                question.QuestionId = newQuestion.QuestionId;
            }

            exam.ExamStatus = ExamStatus.Taken;
            exam.ExamId = 0;

            var jsonExam = JsonConvert.SerializeObject(exam);
            HttpContent httpContent = new StringContent(jsonExam);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var jsonExamDB = await httpClient.PostAsync($"url/userexam/" +userId, httpContent);
        }
      
        public List<Exam> GetStudentExams(int studentId, ExamStatus examStatus)
        {
            var requestUrl = $"{url}/student/{studentId}/{examStatus}";
            var jsonExams = webClient.DownloadString(requestUrl);
            var exams = JsonConvert.DeserializeObject<List<Exam>>(jsonExams);
            return exams;
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

        public List<Exam> GetTakenExams(int classId)
        {
            
            var requestUrl = $"{url}/{classId}/2";
            var jsonExams = webClient.DownloadString(requestUrl);
            var exams = JsonConvert.DeserializeObject<List<Exam>>(jsonExams);
            return exams;
        }
    }
}
