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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Testverktyg.Client.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SplitViewMenuStudent : Page
    {
        private Student _student;
        
        public SplitViewMenuStudent()
        {
            this.InitializeComponent();
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _student = (Student)e.Parameter;
            PageFrame.Navigate(typeof(StudentOverview), _student);
        }

        private void CollapseButton_Click(object sender, RoutedEventArgs e)
        {
            if (MenuSplit.IsPaneOpen)
            {
                MenuSplit.IsPaneOpen = false;
                CollapseButton.Width = 56;
            }
            else
            {
                MenuSplit.IsPaneOpen = true;
                CollapseButton.Width = 130;
            }
        }

       

        private void SplitViewMenuList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (HomeListBoxItem.IsSelected)
            {
                PageFrame.Navigate(typeof(StudentOverview), _student);
                TitleTextblock.Text = "Välkommen";
            }
            else if (ExitListBoxitem.IsSelected)
            {
                _student = null;
                this.Frame.Navigate(typeof(MainPage));
            }
        }
    }
}
