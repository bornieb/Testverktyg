using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestverktygAPI.Models
{
    public class ExamQuestion
    {
        public int ExamId { get; set; }
        public int QuestionId { get; set; }
        public virtual Exam Exam { get; set; }
        public virtual Question Question { get; set; }
    }
}
