using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
            string password = PasswordTextBox.Password;

            if (RadioButtonTeacher.IsChecked == true)
            {
                try
                {
                    var teacher = await userService.GetTeacher(userName, password);

                    if (teacher == null)
                    {
                        await DisplayError("Kunde inte logga in. Kontrollera uppgifterna och försök igen.");
                    }
                    else
                    {
                        this.Frame.Navigate(typeof(SplitViewMenu), teacher);
                    }
                }
                catch(System.Net.Http.HttpRequestException ex)
                {
                    await DisplayError($"{ex.Message}\nNågot blev fel");
                }
            }
            else if (RadioButtonStudent.IsChecked == true)
            {
                try
                {
                    var student = await userService.GetStudent(userName, password);

                    if (student == null)
                    {
                        await DisplayError("Kunde inte logga in. Kontrollera uppgifterna och försök igen.");
                    }
                    else
                    {
                        this.Frame.Navigate(typeof(SplitViewMenuStudent), student);
                    }
                }
                catch (System.Net.Http.HttpRequestException ex)
                {
                    await DisplayError($"{ex.Message}\nNågot blev fel");
                }
            }
            else if (RadioButtonStudent.IsChecked == false && RadioButtonTeacher.IsChecked == false)
            {
                await DisplayError("Du måste välja lärare eller student");
            }
                       
        }

        private async Task DisplayError(string message)
        {
            await new MessageDialog(message).ShowAsync();
        }

        private async void StartLogo_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            try
            {
                    await AdminLoginContent.ShowAsync();
                    this.Frame.Navigate(typeof(SplitViewMenuAdmin));
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                await DisplayError($"{ex.Message}\nNågot blev fel");
            }
        }
    }
}
