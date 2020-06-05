using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testverktyg.Client.Models
{
    class UserExam
    {
        public Student student { get; set; }
        public Exam exam { get; set; }

        public UserExam()
        {

        }
    }
}
