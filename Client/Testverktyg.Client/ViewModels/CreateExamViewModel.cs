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
        ClassService classService;
        QuestionService questionService;
        CourseService courseService;
        public ObservableCollection<Class> ListOfClasses = new ObservableCollection<Class>();
        public ObservableCollection<Question> ListOfQuestions = new ObservableCollection<Question>();
        public ObservableCollection<Course> ListOfCourses = new ObservableCollection<Course>();
        public ObservableCollection<Question> QuestionCart = new ObservableCollection<Question>();
        public List<Exam> ListOfExams = new List<Exam>();
        public Exam exam { get; set; }
        public CreateExamViewModel()
        {
            examService = new ExamService();
            classService = new ClassService();
            questionService = new QuestionService();
            courseService = new CourseService();
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

        public async void GetClasses()
        {
            var classes = await classService.GetClassesAsync();
            foreach (Class item in classes)
            {
                ListOfClasses.Add(item);
            }
        }

        public async void GetQuestions()
        {
            var questions = await questionService.GetQuestionsAsync();
            foreach (Question question in questions)
            {
                ListOfQuestions.Add(question);
            }
        }

        public void GetCourses()
        {
            var courses = courseService.GetCourses();
            foreach (Course course in courses)
            {
                ListOfCourses.Add(course);
            }
        }

        //public void CourseData()
        //{
        //    ListOfClasses.Add(new Class(1, "7A"));
        //    ListOfClasses.Add(new Class(2, "7B"));
        //    ListOfClasses.Add(new Class(3, "8A"));
        //    ListOfClasses.Add(new Class(4, "8B"));
        //    ListOfClasses.Add(new Class(5, "9A"));
        //    ListOfClasses.Add(new Class(6, "9B"));
        //}

        public async Task CreateExamAsync(Exam exam)
        {
            await examService.PostExam(exam);
        }
    }
}
