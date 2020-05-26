using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using Testverktyg.Client.Models;

namespace Testverktyg.Client.Services
{
    public class CourseService
    {
        private WebClient webClient = new WebClient();
        private const string url = "http://localhost:60485/api/course";

        public List<Course> GetCourses() 
        {
            var jsonCourses = webClient.DownloadString(url);
            return JsonConvert.DeserializeObject<List<Course>>(jsonCourses);
        }
    }
}
