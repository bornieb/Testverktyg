using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Testverktyg.Client.Models;
using Testverktyg.Client.ViewModels;
using Windows.ApplicationModel.VoiceCommands;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Testverktyg.Client.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TakeExam : Page, INotifyPropertyChanged
    {
        private TakeExamViewModel viewModel;
        private Student _student;
        private Exam _exam;
        private string placeHolder="";
        private int questionIndex = 0;
        private string currentQuestion { get { return _exam.Questions[questionIndex].QuestionText; } set { value = placeHolder; NotifyPropertyChanged("currentQuestion"); } }
        public List<Alternative> CurrentQuestionAlternatives;
        

        public event PropertyChangedEventHandler PropertyChanged;
        public TakeExam()
        {
            this.InitializeComponent();
            Init();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //_student = (Student)e.Parameter;
            _exam = (Exam)e.Parameter;
            CurrentTestQuestion(questionIndex);
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            if(MultipleChoicesGridView.Visibility == Visibility.Visible)
            {
                MultipleChoicesGridView.Visibility = Visibility.Collapsed;
                FreeAnswerTextBox.Visibility = Visibility.Visible;
            }
            else
            {
                MultipleChoicesGridView.Visibility = Visibility.Visible;
                FreeAnswerTextBox.Visibility = Visibility.Collapsed;
            }
            
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void NextQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            questionIndex++;
            if (questionIndex == _exam.Questions.Count)
            {
                NextQuestionButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                currentQuestion = _exam.Questions[questionIndex].QuestionText;
                NextQuestionButton.Visibility = Visibility.Visible;
            }
        }

        private void NotifyPropertyChanged(string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        private void PreviousQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (questionIndex == 0)
            {
                PreviousQuestionButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                questionIndex--;
                currentQuestion = _exam.Questions[questionIndex].QuestionText;
            }
        }

        private void Init()
        {
            CurrentQuestionAlternatives = new List<Alternative>();
            
        }

        private void CurrentTestQuestion(int questionIndex)
        {
            
               foreach (var alt in _exam.Questions[questionIndex].Alternatives)
               {
                    CurrentQuestionAlternatives.Add(alt);
               }
            
        }


        private async Task DisplayError(string message)
        {
            await new MessageDialog(message).ShowAsync();
        }

        //private void ExamLogic()
        //{
        //    string questionText = "";
        //    for (int i = 0; i <= _exam.Questions.Count; i++)
        //    {
        //        foreach (Question q in _exam.Questions)
        //        {
        //            questionText = q.QuestionText;
        //        }
        //        QuestionTextBlock.Text = $"{questionText}";
        //    }
        //}
    }
}
