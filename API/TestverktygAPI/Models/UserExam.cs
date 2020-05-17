using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestverktygAPI.Models
{
    public class UserExam
    {
        public int UserId { get; set; }
        public int ExamId { get; set; }
        public virtual User User { get; set; }
        public virtual Exam Exam { get; set; }
    }
}
