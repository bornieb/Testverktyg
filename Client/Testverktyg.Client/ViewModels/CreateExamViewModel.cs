using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testverktyg.Client.Models;
using Testverktyg.Client.Services;
using Windows.UI.Popups;
using Windows.UI.Text.Core;

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

        public async Task AddQuestionAsync(Question question)
        {

            if (QuestionCart.Contains(question))
            {
                await new MessageDialog("Frågan existerar redan i provet du vill skapa, vänligen välj en ny fråga.").ShowAsync();
            }
            else
            {
                QuestionCart.Add(question);
            }
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
            var questions = await questionService.GetTemplateQuestions();
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

        public bool ValidateDateField(DateTime dateTime)
        {
            bool success = false;

            if(DateTime.TryParse(dateTime.ToString(), out DateTime result))
            {
                success = true;
            }
            else
            {
                return success;
            }
            return success;
        }

        public bool ValidateTimeSpan(string timeSpan)
        {
            bool success = false;
            if(int.TryParse(timeSpan, out int result))
            {
                success = true;
            }
            return success;
        }

        public async Task CreateExamAsync(Exam exam, int userId)
        {
            await examService.PostExam(exam, userId);
        }
    }
}
