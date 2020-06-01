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
using Testverktyg.Client.Views;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Testverktyg.Client.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StudentOverview : Page
    {
        private StudentOverviewViewModel viewModel;
        private SplitViewMenuStudent split;
        private Student _student;

        public StudentOverview()
        {
            this.InitializeComponent();
            viewModel = new StudentOverviewViewModel();
            split = new SplitViewMenuStudent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _student = (Student)e.Parameter;
            Init();
         
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
           this.Frame.Navigate(typeof(TakeExam),e.ClickedItem);
        }

        private void Init()
        {
            viewModel.LoadData(_student);
        }

        private async void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            await ContentTest.ShowAsync();
        }

       
    }
}
