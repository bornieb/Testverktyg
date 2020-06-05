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
using Windows.UI;
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
        
        public ObservableCollection<Alternative> CurrentQuestionAlternatives;
        

        public event PropertyChangedEventHandler PropertyChanged;
        public TakeExam()
        {
            this.InitializeComponent();
            Init();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            viewModel = new TakeExamViewModel();
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
            PreviousQuestionButton.Visibility = Visibility.Visible;
            questionIndex++;
            if (questionIndex == _exam.Questions.Count)
            {
                NextQuestionButton.Visibility = Visibility.Collapsed;
                SubmitTestButton.Visibility = Visibility.Visible;
                
            }
            else
            {
                currentQuestion = _exam.Questions[questionIndex].QuestionText;
                CurrentTestQuestion(questionIndex);
              
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
            NextQuestionButton.Visibility = Visibility.Visible;
            SubmitTestButton.Visibility = Visibility.Collapsed;
            if (questionIndex == 0)
            {
                PreviousQuestionButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                questionIndex--;
                currentQuestion = _exam.Questions[questionIndex].QuestionText;
                CurrentTestQuestion(questionIndex);
                
            }
        }

        private void Init()
        {
            CurrentQuestionAlternatives = new ObservableCollection<Alternative>();
            
        }

        private void CurrentTestQuestion(int questionIndex)
        {
            CurrentQuestionAlternatives.Clear();

            foreach (var alt in _exam.Questions[questionIndex].Alternatives)
            {
                    CurrentQuestionAlternatives.Add(alt);
            }
            
        }


        private async Task DisplayError(string message)
        {
            await new MessageDialog(message).ShowAsync();
        }

        //private void AlternativeButton_Click(object sender, RoutedEventArgs e)
        //{
        //    {
        //        var selected = MultipleChoicesGridView.SelectedItem;
        //        foreach (var answer in _exam.Questions[questionIndex].Alternatives)
        //        {
                    
        //        }
        //    }
        //}

        private void AlternativeButton_Click(object sender, RoutedEventArgs e)
        {
            Alternative alt = (Alternative)((FrameworkElement)sender).DataContext;
            //alt.StudentAnswer =! alt.StudentAnswer;
        }

        private void MultipleChoicesGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }

        private void MultipleChoicesGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void SubmitTestButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.SecureSubmit(_exam, _student.UserId);
            //För att navigera tillbaka när provet är färdigt
            this.Frame.Navigate(typeof(StudentOverview), _student);
        }

        
       

    }
}
