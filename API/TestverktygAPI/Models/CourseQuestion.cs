using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestverktygAPI.Models
{
    public class CourseQuestion
    {
        public int CourseId { get; set; }
        public int QuestionId { get; set; }
        public virtual Course Course { get; set; }
        public virtual Question Question { get; set; }
    }
}
