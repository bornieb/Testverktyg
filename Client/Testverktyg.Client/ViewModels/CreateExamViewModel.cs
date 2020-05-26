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
        public ObservableCollection<Question> QuestionCart = new ObservableCollection<Question>();
        public List<Exam> ListOfExams = new List<Exam>();
        public List<Course> ListOfCourses = new List<Course>();
        public List<Class> ListOfClasses = new List<Class>();
        public Exam exam { get; set; }
        public CreateExamViewModel()
        {
            examService = new ExamService();
            exam = new Exam();
        }

        
        public void AddQuestion(Question question)
        {
            QuestionCart.Add(question);
        }

        public void RemoveQuestion(Question question)
        {
            QuestionCart.Remove(question);
        }

        public void CourseData()
        {
            ListOfClasses.Add(new Class(1, "7A"));
            ListOfClasses.Add(new Class(2, "7B"));
            ListOfClasses.Add(new Class(3, "8A"));
            ListOfClasses.Add(new Class(4, "8B"));
            ListOfClasses.Add(new Class(5, "9A"));
            ListOfClasses.Add(new Class(6, "9B"));
        }

        public async Task CreateExamAsync(Exam exam)
        {
            await examService.PostExam(exam);
        }
    }
}
