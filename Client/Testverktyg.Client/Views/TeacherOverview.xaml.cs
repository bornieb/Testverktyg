using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Testverktyg.Client.Models;
using Testverktyg.Client.Services;
using Testverktyg.Client.ViewModels;
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
    public sealed partial class TeacherOverview : Page
    {
        private Teacher _teacher;
        TeacherOverviewViewModel teacherOverviewViewModel;
        ExamService examService;

        public TeacherOverview()
        {
            this.InitializeComponent();
            Init();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _teacher = (Teacher)e.Parameter;
        }

        private void CreateTestButton_Click(object sender, RoutedEventArgs e)
        {

        }


        private void Remove1Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CorrectTestButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Remove2Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void GetTests_Click(object sender, RoutedEventArgs e)
        {
            //GetTakenExams(ClassDropDown.SelectedItem);

            bool validClass = false;
            int classId=0; 
            

            if ((Class)ClassDropDown.SelectedValue != null)
            {
                classId = ((Class)ClassDropDown.SelectedValue).ClassId;
                teacherOverviewViewModel.GetTakenExams(classId);
                teacherOverviewViewModel.GetNotTakenExams(classId);
                validClass = true;
            }
            else
            {
                await DisplayError("Vänligen välj en giltig klass.");
            }

            if (validClass)
            {
                examService.GetTakenExams(classId);
                examService.GetNotTakenExams(classId);
            }

        }
        private async Task DisplayError(string message)
        {
            await new MessageDialog(message).ShowAsync();
        }

        private void Init()
        {
            examService = new ExamService();
            teacherOverviewViewModel = new TeacherOverviewViewModel();
            teacherOverviewViewModel.GetClasses();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Frame.Navigate(typeof(CorrectExam));
        }

    }
}
