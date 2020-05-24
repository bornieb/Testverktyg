using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Testverktyg.Client.Models;
using Testverktyg.Client.ViewModels;
using Testverktyg.Client.Services;
using Windows.UI.Popups;

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
            question.QuestionText = QuestionTextBox.Text;
            question.GradeLevel = (GradeLevel)GradeLevelDropDown.SelectedValue;
            question.QuestionType = (QuestionType)QuestionTypeDropDown.SelectedValue;
            question.CourseId = ((Course)CourseDropDown.SelectedValue).CourseId;
            question.Alternatives.AddRange(viewModel.Alternatives);
            question.Keywords.AddRange(viewModel.Keywords);
            questionService.AddQuestion(question);
            await new MessageDialog("Din fråga har sparats").ShowAsync();
            ClearAllInputs();
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
    }
}
