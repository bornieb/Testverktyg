using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testverktyg.Client.Models
{
    public class Student:User
    {
        public int ClassId { get; set; }

        public Student(int userid, string firstname, string lastname, string usernameemail, string password, int classid)
            :base(userid, firstname, lastname, usernameemail, password)
        {
            ClassId = classid;
        }
        public Student()
        {

        }
    }
}
