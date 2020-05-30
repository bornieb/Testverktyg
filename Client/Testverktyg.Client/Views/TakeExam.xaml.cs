using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Testverktyg.Client.Models;
using Testverktyg.Client.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class TakeExam : Page
    {
        private TakeExamViewModel viewModel;
        private Student _student;

        public TakeExam()
        {
            this.InitializeComponent();
            //    viewModel = TakeExamViewModel.Instance;
            //    viewModel.Questions.Clear();
            //    viewModel.QuestionsInTest();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _student = (Student)e.Parameter;
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
    }
}
