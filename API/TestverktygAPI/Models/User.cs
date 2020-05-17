using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestverktygAPI.Models
{
    public abstract class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserNameEmail { get; set; }
        public string PassWord { get; set; }
        public List<Exam> Exams { get; set; } = new List<Exam>();
        public List<UserExam> UserExams { get; set; } = new List<UserExam>();
    }
}
