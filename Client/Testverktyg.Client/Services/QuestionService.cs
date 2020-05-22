using Newtonsoft.Json;
using System.Net;
using Testverktyg.Client.Models;

namespace Testverktyg.Client.Services
{
    public class QuestionService
    {
        private const string url = "http://localhost:60485/api/question";

        public void AddQuestion(Question question)
        {
            var jsonQuestion = JsonConvert.SerializeObject(question);
            var webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            var response = webClient.UploadString(url, "POST", jsonQuestion);
        }
    }
}
