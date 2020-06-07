using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Testverktyg.Client.Models;
using Testverktyg.Client.ViewModels;
using Testverktyg.Client.Services;
using Windows.UI.Popups;
using System.Threading.Tasks;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Testverktyg.Client.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateQuestion : Page
    {
        private CreateQuestionViewModel viewModel;

        public List<Course> ListOfCourses;
        private CourseService courseService = new CourseService();
        private QuestionService questionService = new QuestionService();
        private Teacher _teacher;

        public CreateQuestion()
        {
            this.InitializeComponent();
            //CourseDropDown.ItemsSource = Enum.GetValues(typeof(Course));
            Init();
            
        }

        public void Init()
        {
            ListOfCourses = courseService.GetCourses();

            QuestionTypeDropDown.ItemsSource = Enum.GetValues(typeof(QuestionType));
            GradeLevelDropDown.ItemsSource = Enum.GetValues(typeof(GradeLevel));

            viewModel = new CreateQuestionViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _teacher = (Teacher)e.Parameter;
        }

        private void AddAlternativeBtn_Click(object sender, RoutedEventArgs e)
        {
            string alternative = AlternativeTextBox.Text;
            bool isCorrect = RightAnswerRadioBtn.IsChecked ?? false;
            viewModel.AddAlternative(alternative, isCorrect);
        }

        private void AddKeyword_Click(object sender, RoutedEventArgs e)
        {
            string keyword = KeywordTextBox.Text;
            viewModel.AddKeyword(keyword);
        }

        private async void SaveQuestionBtn_Click(object sender, RoutedEventArgs e)
        {
            Question question = new Question();
            List<string> errorMessages = new List<string>();


            if (string.IsNullOrWhiteSpace(QuestionTextBox.Text))
            {
                errorMessages.Add("Vänligen fyll i en fråga.");
            }
            else
            {
                question.QuestionText = QuestionTextBox.Text;
            }

            if (GradeLevelDropDown.SelectedValue == null)
            {
                errorMessages.Add("Vänligen välj en årskurs.");
            }
            else
            {
                question.GradeLevel = (GradeLevel)GradeLevelDropDown.SelectedValue;
            }
            
            if (QuestionTypeDropDown.SelectedValue == null)
            {
                errorMessages.Add("Vänligen välj en frågetyp.");
            }
            else
            {
                question.QuestionType = (QuestionType)QuestionTypeDropDown.SelectedValue;
            }

            if (CourseDropDown.SelectedValue == null)
            {
                errorMessages.Add("Vänligen välj ämne.");
            }
            else
            {
                question.CourseId = ((Course)CourseDropDown.SelectedValue).CourseId;
            }

            if (question.QuestionType == QuestionType.MultipleChoice && viewModel.Alternatives.Count == 0)
            {
                errorMessages.Add("Vänligen lägg till alternativ.");
            }
            else
            {
                question.Alternatives.AddRange(viewModel.Alternatives);
            }

            question.Keywords.AddRange(viewModel.Keywords);

            if (errorMessages.Count == 0)
            {
                questionService.AddQuestion(question);
                await new MessageDialog("Din fråga har sparats").ShowAsync();
                ClearAllInputs();
            }
            else
            {
                string error = string.Join("\n", errorMessages);
                await DisplayError(error);
            }
            
        }

        private void RemoveAlternativeBtn_Click(object sender, RoutedEventArgs e)
        {
            Alternative alternative = (Alternative)((Button)sender).DataContext;
            viewModel.RemoveAlternative(alternative);
        }

        private void RemoveKeywordBtn_Click(object sender, RoutedEventArgs e)
        {
            Keyword keyword = (Keyword)((Button)sender).DataContext;
            viewModel.RemoveKeyword(keyword);
        }

        private void ClearAllInputs()
        {
            QuestionTextBox.Text = "";
            KeywordTextBox.Text = "";
            AlternativeTextBox.Text = "";
            RightAnswerRadioBtn.IsChecked = false;
            WrongAnswerRadioBtn.IsChecked = false;
            viewModel.Alternatives.Clear();
            viewModel.Keywords.Clear();
        }

        private void ClearInputBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearAllInputs();
        }

        private async Task DisplayError(string message)
        {
            await new MessageDialog(message).ShowAsync();
        }
    }
}
