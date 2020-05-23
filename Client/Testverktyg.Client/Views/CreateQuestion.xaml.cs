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
            viewModel.Question.AddAlternative(alternative, isCorrect);
        }

        private void AddKeyword_Click(object sender, RoutedEventArgs e)
        {
            string keyword = KeywordTextBox.Text;
            viewModel.Question.AddKeyword(keyword);
        }

        private async void SaveQuestionBtn_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Question.QuestionText = QuestionTextBox.Text;
            viewModel.Question.GradeLevel = (GradeLevel)GradeLevelDropDown.SelectedValue;
            viewModel.Question.QuestionType = (QuestionType)QuestionTypeDropDown.SelectedValue;
            viewModel.Question.CourseId = ((Course)CourseDropDown.SelectedValue).CourseId;
            questionService.AddQuestion(viewModel.Question);
            await new MessageDialog("Din fråga har sparats").ShowAsync();
            Init();
        }

        private void RemoveAlternativeBtn_Click(object sender, RoutedEventArgs e)
        {
            Alternative alternative = (Alternative)((Button)sender).DataContext;
            viewModel.Question.RemoveAlternative(alternative);
        }

        private void RemoveKeywordBtn_Click(object sender, RoutedEventArgs e)
        {
            Keyword keyword = (Keyword)((Button)sender).DataContext;
            viewModel.Question.RemoveKeyword(keyword);
        }

        private void ClearAllInputs()
        {
            QuestionTextBox.Text = "";
            KeywordTextBox.Text = "";
            AlternativeTextBox.Text = "";
            RightAnswerRadioBtn.IsChecked = false;
            WrongAnswerRadioBtn.IsChecked = false;
        }
    }
}
