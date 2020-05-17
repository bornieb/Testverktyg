using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestverktygAPI.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public List<CourseExam> CourseExams { get; set; }
        public List<CourseQuestion> CourseQuestions { get; set; }
    }
}
