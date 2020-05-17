using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestverktygAPI.Models
{
    public class CourseExam
    {
        public int CourseId { get; set; }
        public int ExamId { get; set; }
        public virtual Course Course { get; set; }
        public virtual Exam Exam { get; set; }
    }
}
