using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testverktyg.Client.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public Course(int courseid, string coursename)
        {
            CourseId = courseid;
            CourseName = coursename;
        }
    }
}
