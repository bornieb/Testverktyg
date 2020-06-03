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
using System.Threading.Tasks;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Testverktyg.Client.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateExam : Page
    {
        CreateExamViewModel createExamViewModel;
        private Teacher _teacher;
        public ObservableCollection<string> ErrorMessages = new ObservableCollection<string>();

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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _teacher = (Teacher)e.Parameter;
        }

        private async void CreateExamBtn_Click(object sender, RoutedEventArgs e)
        {

            Exam exam = new Exam();
            string errorSummary = "";
            #region
            if ((Class)ClassDropDown.SelectedValue != null)
            {
                exam.ClassId = ((Class)ClassDropDown.SelectedValue).ClassId;
            }
            else
            {
                ErrorMessages.Add("Vänligen välj en giltig klass. \n");
                //await DisplayError("Vänligen välj en giltig klass.");
            }
            
            DateTime dt = new DateTime(ExamDatePicker.Date.Year, ExamDatePicker.Date.Month, ExamDatePicker.Date.Day,
            ExamStartTimePicker.Time.Hours, ExamStartTimePicker.Time.Minutes, ExamStartTimePicker.Time.Seconds);

            if (createExamViewModel.ValidateDateField(dt))
            {
                exam.ExamDate = dt;
            }
            else
            {
                ErrorMessages.Add("Vänligen välj ett giltigt datum. \n");
                //await DisplayError("Vänligen välj ett giltigt datum.");
            }

            if (int.TryParse(TimeLimitTextBox.Text, out int examTimeSpan))
            {

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
            }
            else
            {
                ErrorMessages.Add("Vänligen skriv in en giltig provtid i minuter. \n");
                //await DisplayError("Vänligen skriv in en giltig provtid i minuter.");
            }

            if (!string.IsNullOrEmpty(SubjectTextBox.Text))
            {
                exam.Subject = SubjectTextBox.Text;
            }
            else
            {
                ErrorMessages.Add("Vänligen skriv in en titel till provet. \n");
                //await DisplayError("Vänligen skriv in en titel till provet.");
            }

            var duplicateList = createExamViewModel.QuestionCart.GroupBy(x => x)
                  .Where(g => g.Count() > 1)
                  .Select(y => y.Key)
                  .ToList();

            if (createExamViewModel.QuestionCart.Count > 0) 
            {
                if (duplicateList.Count > 0)
                {
                    await DisplayError("Det existerar två eller fler likadana frågor i provet, vänligen ta bort en och försök igen.");
                }
                else
                {
                    exam.TotalPoints = createExamViewModel.QuestionCart.Count;
                    exam.NumberOfQuestions = createExamViewModel.QuestionCart.Count;
                    exam.Questions = createExamViewModel.QuestionCart;
                }
            }
            else
            {
                ErrorMessages.Add("Vänligen lägg in frågor som provet ska innehålla. \n" );
                //await DisplayError("Vänligen lägg in frågor som provet ska innehålla.");
            }


                


            if(int.TryParse(GradeScaleTextBox.Text, out int result))
            {
                exam.GradeScale = result;
            }
            else
            {
                ErrorMessages.Add("Vänligen skriv in en giltig betygsgräns till provet. \n");
                //await DisplayError("Vänligen skriv in en betygsgräns till provet.");
            }


            exam.CurrentQuestion = 0;
            exam.ExamResult = 0;
            exam.ExamStatus = ExamStatus.Template;

            if(ExamTypeDropDown.SelectedValue != null)
            {
                exam.ExamType = (ExamType)ExamTypeDropDown.SelectedValue;
            }
            else
            {
                ErrorMessages.Add("Vänligen välj en provtyp. \n");
                //await DisplayError("Vänligen välj en provtyp.");
            }

            #endregion

            if (ErrorMessages.Count == 0)
            {
                string Summary = $"Provdatum: {exam.ExamDate.ToString("dddd, dd MMMM yyyy")} \n" +
                    $"Provtitel: {SubjectTextBox.Text} \n" +
                    $"Antal frågor: {createExamViewModel.QuestionCart.Count} \n" +
                    $"Provtid i minuter: {examTimeSpan}";

                await createExamViewModel.CreateExamAsync(exam);
                await new MessageDialog(Summary, "Provet har skapats!").ShowAsync();
                ClearFields();
            }
            else
            {
                foreach (var item in ErrorMessages)
                {
                    errorSummary += item;
                }
                await DisplayError(errorSummary);
                ErrorMessages.Clear();
            }
        }

        private async void AddToQCart_Click(object sender, RoutedEventArgs e)
        {
            await createExamViewModel.AddQuestionAsync((Question)QuestionListView.SelectedItem);
            AddToTextBlocks();
        }

        private void RemoveQuestionBtn_Click(object sender, RoutedEventArgs e)
        {
            Question question = (Question)((Button)sender).DataContext;
            createExamViewModel.RemoveQuestion(question);
            AddToTextBlocks();
        }

        public void AddToTextBlocks()
        {
            AmountOfQTextBlock.Text = $"Antal frågor: {createExamViewModel.QuestionCart.Count}";
            TotalPointsTextBlock.Text = $"Maxpoäng: {createExamViewModel.QuestionCart.Count}";
        }
        private void ClearFormBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }
        private async Task DisplayError(string message)
        {
            await new MessageDialog(message).ShowAsync();
        }

        private void ClearFields()
        {
            createExamViewModel.QuestionCart.Clear();
            GradeScaleTextBox.Text = "";
            SubjectTextBox.Text = "";
            TimeLimitTextBox.Text = "";
            ExamDatePicker.SelectedDate = DateTime.Now;
            ExamStartTimePicker.SelectedTime = TimeSpan.Zero;
            ClassDropDown.SelectedIndex = -1;
            CourseDropDown.SelectedIndex = -1;
            ExamTypeDropDown.SelectedIndex = -1;
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
