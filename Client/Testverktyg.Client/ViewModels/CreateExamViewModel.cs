using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testverktyg.Client.Models;
using Testverktyg.Client.Services;

namespace Testverktyg.Client.ViewModels
{
    class CreateExamViewModel
    {
        ExamService examService;
        public ObservableCollection<Question> ListOfQuestions = new ObservableCollection<Question>();
        public List<Exam> ListOfExams = new List<Exam>();
        public List<Course> ListOfCourses = new List<Course>();
        public List<GradeLevel> ListOfGrades = new List<GradeLevel>();
        public List<Class> ListOfClasses = new List<Class>();

        public CreateExamViewModel()
        {
            examService = new ExamService();
        }
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

        public bool CreateExam(Exam exam)
        {
            examService.PostExam(exam);
            bool success = true;
            
            return success;
        }
    }
}
