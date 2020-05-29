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
        CreateExamViewModel createExamViewModel;
        public CreateExam()
        {
            this.InitializeComponent();
            Init();
        }
        public void Init()
        {
            createExamViewModel = new CreateExamViewModel();
            createExamViewModel.GetCourses();
            createExamViewModel.GetClasses();
            createExamViewModel.GetQuestions();
            ExamTypeDropDown.ItemsSource = Enum.GetValues(typeof(ExamType));
        }
        private async void CreateExamBtn_Click(object sender, RoutedEventArgs e)
        {
            bool validClass = false;
            bool validDate = false;
            bool validTimeSpan = false;
            bool validSubject = false;
            bool validQuestion = false;
            bool validGradeS = false;


            Exam exam = new Exam();

            if((Class)ClassDropDown.SelectedValue != null)
            {
                exam.ClassId = ((Class)ClassDropDown.SelectedValue).ClassId;
                validClass = true;
            }
            else
            {
                await new MessageDialog("Välj en giltigt klass!").ShowAsync();
            }


            DateTime dt = new DateTime(ExamDatePicker.Date.Year, ExamDatePicker.Date.Month, ExamDatePicker.Date.Day,
            ExamStartTimePicker.Time.Hours, ExamStartTimePicker.Time.Minutes, ExamStartTimePicker.Time.Seconds);

            if (createExamViewModel.ValidateDateField(dt))
            {
                exam.ExamDate = dt;
                validDate = true;
            }
            else
            {
                await new MessageDialog("Skriv in ett giltigt datum!").ShowAsync();
            }

            string timeSpan = TimeLimitTextBox.Text;
            if (int.TryParse(timeSpan, out int examTimeSpan))
            {

                if (examTimeSpan < 60)
                {
                    exam.ExamTimeSpan = new TimeSpan(0, examTimeSpan, 0);
                    validTimeSpan = true;
                }
                else
                {
                    int hours = examTimeSpan / 60;
                    int minutes = examTimeSpan % 60;
                    exam.ExamTimeSpan = new TimeSpan(hours, minutes, 0);
                    validTimeSpan = true;
                }
            }
            else
            {
                await new MessageDialog("Skriv in en giltig provtid i minuter!").ShowAsync();
            }

            if (!string.IsNullOrEmpty(SubjectTextBox.Text))
            {
                exam.Subject = SubjectTextBox.Text;
                validSubject = true;
            }
            else
            {
                await new MessageDialog("Skriv in en provtitel!").ShowAsync();
            }

            if (createExamViewModel.QuestionCart.Count > 0) 
            {
                exam.TotalPoints = createExamViewModel.QuestionCart.Count;
                exam.NumberOfQuestions = createExamViewModel.QuestionCart.Count;
                exam.Questions = createExamViewModel.QuestionCart;
                validQuestion = true;
            }
            else
            {
                await new MessageDialog("Lägg in frågor i provkundvagnen!").ShowAsync();
            }


            if(int.TryParse(GradeScaleTextBox.Text, out int result))
            {
                exam.GradeScale = result;
                validGradeS = true;
            }
            else
            {
                await new MessageDialog("Skriv in en betygsgräns!").ShowAsync();
            }


            exam.CurrentQuestion = 0;
            exam.ExamResult = 0;
            exam.ExamStatus = ExamStatus.Template;
            

            if((ExamType)ExamTypeDropDown.SelectedValue != null)
            {
                exam.ExamType = (ExamType)ExamTypeDropDown.SelectedValue;
            }
            else
            {
                await new MessageDialog("Välj en provtyp!").ShowAsync();
            }

            exam.ExamType = ((ExamType)ExamTypeDropDown.SelectedValue);

            //Skapar provet
            if (validClass && validDate && validTimeSpan && validSubject && validQuestion && validGradeS) {
                MessageDialog msg = new MessageDialog("Provet skapat!");
                await msg.ShowAsync();

                string Summary = $"Datum: {exam.ExamDate} Tid: {exam.ExamTimeSpan} Klass: {exam.ClassId} Ämne: {exam.Subject} Maxpoäng: {exam.TotalPoints} Antal frågor: {exam.NumberOfQuestions}" +
                    $"{exam.GradeScale}{exam.ExamResult}{exam.ExamStatus}{exam.ExamType}";

                MessageDialog sum = new MessageDialog(Summary);
                await sum.ShowAsync();


                await createExamViewModel.CreateExamAsync(exam);
            }
        }

        private void AddToQCart_Click(object sender, RoutedEventArgs e)
        {
            createExamViewModel.AddQuestion((Question)QuestionTextBox.SelectedItem);
            AmountOfQTextBlock.Text = $"Antal frågor: {createExamViewModel.QuestionCart.Count}";
            TotalPointsTextBlock.Text = $"Maxpoäng: {createExamViewModel.QuestionCart.Count}";
            //AmountOfQTextBlock.Text = $"Antal frågor: {createExamViewModel.exam.NumberOfQuestions}";

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
