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
        public List<Class> ListOfClasses = new List<Class>();
        public void CreateExamData()
        {
            ListOfQuestions.Add(new Question());
        }

        public void CourseData()
        {
            ListOfCourses.Add(new Course(1, "Svenska"));
            ListOfCourses.Add(new Course(1, "Engelska"));
            ListOfCourses.Add(new Course(1, "Matematik"));


            ListOfClasses.Add(new Class(1, "7A"));
            ListOfClasses.Add(new Class(1, "7B"));
            ListOfClasses.Add(new Class(1, "8A"));
            ListOfClasses.Add(new Class(1, "8B"));
            ListOfClasses.Add(new Class(1, "9A"));
            ListOfClasses.Add(new Class(1, "9B"));
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
