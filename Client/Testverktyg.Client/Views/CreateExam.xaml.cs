using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Testverktyg.Client.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Testverktyg.Client.ViewModels;
using Testverktyg.Client.Services;
using System.Security.Cryptography.X509Certificates;
using System.Collections.ObjectModel;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Testverktyg.Client.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateExam : Page
    {
        public List<Course> ListOfCourses;
        CreateExamViewModel createExamViewModel;
        ExamService examService;
        CourseService courseService;
        QuestionService questionService;
        public CreateExam()
        {
            this.InitializeComponent();
            Init();
        }
        public void Init()
        {
            courseService = new CourseService();
            createExamViewModel = new CreateExamViewModel();
            examService = new ExamService();
            questionService = new QuestionService();
            createExamViewModel.CourseData();
            ListOfCourses = courseService.GetCourses();
            ExamTypeDropDown.ItemsSource = Enum.GetValues(typeof(ExamType));
            GetQuestions();
        }
        private async void CreateExamBtn_Click(object sender, RoutedEventArgs e)
        {

            Exam exam = new Exam();

            exam.ClassId = ((Class)ClassDropDown.SelectedValue).ClassId;

            exam.ExamDate = new DateTime(ExamDatePicker.Date.Year, ExamDatePicker.Date.Month, ExamDatePicker.Date.Day,
            ExamStartTimePicker.Time.Hours, ExamStartTimePicker.Time.Minutes, ExamStartTimePicker.Time.Seconds);

            int examTimeSpan = Convert.ToInt32(TimeLimitTextBox.Text);

            if (examTimeSpan < 60)
            {
                exam.ExamTimeSpan = new TimeSpan(0, examTimeSpan, 0);
            }
            else
            {
                int hours = examTimeSpan / 60;
                int minutes = examTimeSpan % 60;
                exam.ExamTimeSpan = new TimeSpan(hours, minutes, 0);
            }


            exam.Subject = SubjectTextBox.Text;
            exam.TotalPoints = createExamViewModel.QuestionCart.Count;
            exam.NumberOfQuestions = createExamViewModel.QuestionCart.Count;
            exam.GradeScale = Convert.ToInt32(GradeScaleTextBox.Text);
            exam.CurrentQuestion = 0;
            exam.ExamResult = 0;
            exam.ExamStatus = ExamStatus.Template;
            exam.ExamType = ((ExamType)ExamTypeDropDown.SelectedValue);
            exam.Questions = createExamViewModel.QuestionCart;

            //Skapar provet

            MessageDialog msg = new MessageDialog("Provet skapat!");
            await msg.ShowAsync();

            string Summary = $"Datum: {exam.ExamDate} Tid: {exam.ExamTimeSpan} Klass: {exam.ClassId} Ämne: {exam.Subject} Maxpoäng: {exam.TotalPoints} Antal frågor: {exam.NumberOfQuestions}" +
                $"{exam.GradeScale}{exam.ExamResult}{exam.ExamStatus}{exam.ExamType}";

            MessageDialog sum = new MessageDialog(Summary);
            await sum.ShowAsync();

            await createExamViewModel.CreateExamAsync(exam);

        }

        private void AddToQCart_Click(object sender, RoutedEventArgs e)
        {
            createExamViewModel.AddQuestion((Question)QuestionTextBox.SelectedItem);
            AmountOfQTextBlock.Text = $"Antal frågor: {createExamViewModel.QuestionCart.Count}";
            TotalPointsTextBlock.Text = $"Maxpoäng: {createExamViewModel.QuestionCart.Count}";
        }


        private async void GetQuestions()
        {
            var questions = await questionService.GetQuestionsAsync();
            foreach (Question question in questions)
            {
                createExamViewModel.ListOfQuestions.Add(question);
            }
        }

        private void RemoveQuestionBtn_Click(object sender, RoutedEventArgs e)
        {
            Question question = (Question)((Button)sender).DataContext;
            createExamViewModel.RemoveQuestion(question);
            AmountOfQTextBlock.Text = $"Antal frågor: {createExamViewModel.QuestionCart.Count}";
            TotalPointsTextBlock.Text = $"Maxpoäng: {createExamViewModel.QuestionCart.Count}";

        }
    }
}
