using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testverktyg.Client.Models;

namespace Testverktyg.Client.ViewModels
{
    class CreateExamViewModel
    {

        public List<Question> ListOfQuestions = new List<Question>();
        public List<Exam> ListOfExams = new List<Exam>();
        public List<Course> ListOfCourses = new List<Course>();
        public List<GradeLevel> ListOfGrades = new List<GradeLevel>();
        public void CreateExamData()
        {
            ListOfQuestions.Add(new Question());
        }

        public void CourseData()
        {
            ListOfCourses.Add(new Course(1, "Svenska"));
            ListOfCourses.Add(new Course(1, "Engelska"));
            ListOfCourses.Add(new Course(1, "Matematik"));
        }

        public void GradeLevel()
        {

        }

        public bool CreateExam()
        {
            bool success = true;
            return success;
        }
    }
}
