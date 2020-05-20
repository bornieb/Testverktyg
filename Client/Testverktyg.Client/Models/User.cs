using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testverktyg.Client.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserNameEmail { get; set; }
        public string PassWord { get; set; }
        public List<Exam> Exams { get; set; } = new List<Exam>();

        public User(int userid, string firstname, string lastname, string usernameemail, string password)
        {
            UserId = userid;
            FirstName = firstname;
            LastName = lastname;
            UserNameEmail = usernameemail;
            PassWord = password;
            Exams = new List<Exam>();
        }
        public int MyProperty { get; set; }
    }
}
