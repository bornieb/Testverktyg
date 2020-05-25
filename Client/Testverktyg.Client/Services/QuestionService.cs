using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Testverktyg.Client.Models;

namespace Testverktyg.Client.Services
{
    public class QuestionService
    {
        private const string url = "http://localhost:60485/api/question";
        private WebClient webClient = new WebClient();
        ObservableCollection<Question> ListOfQuestions = new ObservableCollection<Question>();
        HttpClient httpClient;

        public QuestionService()
        {
            httpClient = new HttpClient();
        }

        public void AddQuestion(Question question)
        {
            var jsonQuestion = JsonConvert.SerializeObject(question);
            var webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            var response = webClient.UploadString(url, "POST", jsonQuestion);
        }

        
        public async Task<ObservableCollection<Question>> GetQuestionsAsync()
        {
            var jsonQuestions = await httpClient.GetStringAsync(url);
            var questions = JsonConvert.DeserializeObject<ObservableCollection<Question>>(jsonQuestions);
            return questions;
        }
    }
}
