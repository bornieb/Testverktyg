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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Testverktyg.Client.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateQuestion : Page
    {
        private CreateQuestionViewModel viewModel;

        public List<Course> ListOfCourses = new List<Course>();
        public CreateQuestion()
        {
            this.InitializeComponent();
            //CourseDropDown.ItemsSource = Enum.GetValues(typeof(Course));
            Init();
            
        }

        public void Init()
        {
            ListOfCourses.Add(new Course(1, "Matematik"));
            ListOfCourses.Add(new Course(1, "Svenska"));
            ListOfCourses.Add(new Course(1, "Engelska"));

            QuestionTypeDropDown.ItemsSource = Enum.GetValues(typeof(QuestionType));
            GradeLevelDropDown.ItemsSource = Enum.GetValues(typeof(GradeLevel));

            viewModel = new CreateQuestionViewModel();
        }

        private void AddAlternativeBtn_Click(object sender, RoutedEventArgs e)
        {
            string alternative = AlternativeTextBox.Text;
            viewModel.Question.AddAlternative(alternative);
        }

        private void AddKeyword_Click(object sender, RoutedEventArgs e)
        {
            string keyword = KeywordTextBox.Text;
            viewModel.Question.AddKeyword(keyword);
        }
    }
}
