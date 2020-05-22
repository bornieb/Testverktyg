using System.Collections.Generic;

namespace TestverktygAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserNameEmail { get; set; }
        public string PassWord { get; set; }
        public virtual List<Exam> Exams { get; set; } = new List<Exam>();
        public virtual List<UserExam> UserExams { get; set; } = new List<UserExam>();
    }
}
