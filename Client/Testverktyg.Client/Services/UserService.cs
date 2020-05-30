using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Testverktyg.Client.Models;

namespace Testverktyg.Client.Services
{
    public class UserService
    {
        private HttpClient httpClient;
        private const string studentUrl = "http://localhost:60485/api/student";
        private const string teacherUrl = "http://localhost:60485/api/teacher";

        public UserService()
        {
            httpClient = new HttpClient();
        }

        public async Task<Teacher> GetTeacher(string userName, string password)
        {
            var jsonTeacher = await httpClient.GetStringAsync(teacherUrl+$"/checkteacher?userName={userName}&password={password}");
            var teacher = JsonConvert.DeserializeObject<Teacher>(jsonTeacher);
            return teacher;
        }

        public async Task<Student> GetStudent(string userName, string password)
        {
            var jsonStudent = await httpClient.GetStringAsync(studentUrl+$"/checkstudent?userName={userName}&password={password}");
            var student = JsonConvert.DeserializeObject<Student>(jsonStudent);
            return student;
        }
    }
}
