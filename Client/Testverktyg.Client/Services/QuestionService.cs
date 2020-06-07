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

        public Question AddQuestion(Question question)
        {
            var jsonQuestion = JsonConvert.SerializeObject(question);
            var webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            var response = webClient.UploadString(url, "POST", jsonQuestion);
            return JsonConvert.DeserializeObject<Question>(response);
        }

        
        public async Task<ObservableCollection<Question>> GetTemplateQuestions()
        {
            var templateUrl = url + "/template";
            var jsonQuestions = await httpClient.GetStringAsync(templateUrl);
            var questions = JsonConvert.DeserializeObject<ObservableCollection<Question>>(jsonQuestions);
            return questions;
        }
    }
}
