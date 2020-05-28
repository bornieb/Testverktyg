using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Testverktyg.Client.Models;
using Testverktyg.Client.Services;
using Testverktyg.Client.Views;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Testverktyg.Client
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private UserService userService = new UserService();
               
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            string userName = UserNameTextBox.Text;
            string password = PasswordTextBox.Text;

            //var user = await userService.GetUser(userName, password);
            //if (user != null)
            //{

                if (RadioButtonTeacher.IsChecked == true /*&& user.GetType() == typeof(Teacher) && user.GetType() != typeof(Student)*/)
                {
                    //if(user.GetType() == typeof(Teacher) && user.GetType() != typeof(Student))
                    //{
                    //    await new MessageDialog($"Incorrect choice").ShowAsync();
                    //}
                    this.Frame.Navigate(typeof(SplitViewMenu));
                    
                    
                }
                else if (RadioButtonStudent.IsChecked == true /*&& user.GetType() == typeof(Student) && user.GetType() != typeof(Teacher)*/)
                {
                    this.Frame.Navigate(typeof(SplitViewMenuStudent));
                }
                else if (RadioButtonStudent.IsChecked == false && RadioButtonTeacher.IsChecked == false)
                {
                    await new MessageDialog("You have to choose either Teacher or Student").ShowAsync();
                }
            //}
        }

       
    }
}
