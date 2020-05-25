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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Testverktyg.Client.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateExam : Page
    {
        CreateExamViewModel createExamViewModel;
        ExamService examService;
        public CreateExam()
        {
            this.InitializeComponent();
            Init();
        }
        public void Init()
        {
            createExamViewModel = new CreateExamViewModel();
            examService = new ExamService();
            createExamViewModel.CourseData();

            ClassDropDown.ItemsSource = createExamViewModel.ListOfClasses;
            ExamTypeDropDown.ItemsSource = Enum.GetValues(typeof(ExamType));
        }
        private void CreateExamBtn_Click(object sender, RoutedEventArgs e)
        {

            Exam exam = new Exam();

            //ExamDate
            exam.ExamDate = new DateTime(ExamDatePicker.Date.Year, ExamDatePicker.Date.Month, ExamDatePicker.Date.Day,
            ExamStartTimePicker.Time.Hours, ExamStartTimePicker.Time.Minutes, ExamStartTimePicker.Time.Seconds);

            //ExamTimeSpan
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

            //ClassID
            exam.ClassId = ((Class)CourseDropDown.SelectedValue).ClassId;

            //Subject
            exam.Subject = SubjectTextBox.Text;

            //MaxAmountOfPoints
            //int totalPoints = questionlista.count;
            //foreach (Question question in *questionlista*)
            //{
            //totalPoints = question.
            //}

            //NumberOfQuestions
            //*Questionslista.Count*

            //GradeScale?!?!

            //ExamResult null

            //foreach (Question question in *questionlista*)
            //{
            //lokalLista.Add(new Question());
            //}

        }
    }
}
