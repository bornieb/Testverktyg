using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testverktyg.Client.Models;
using Testverktyg.Client.Views;
using Windows.UI.Popups;

namespace Testverktyg.Client.ViewModels
{
    class MainPageViewModel
    {
        //public async void NoChoiceMade ()
        //{
        //    if(RadioButtonStudent.IsCheked == false && RadioButtonTeacher.IsChecked == false)
        //    {
        //        await new MessageDialog("You have to choose either Teacher or Student").ShowAsync();
        //    }
        //}

        ObservableCollection<Student> ListOfStudents = new ObservableCollection<Student>();

        public void TestUser()
        {
            ListOfStudents.Add(new Student(1, "Glenn", "Jönsson", "glennemannen@hotmail.com", "hejsan", 1));
            ListOfStudents.Add(new Student(2, "Eric", "Hedin", "eric@hotmail.com", "hejsan", 2));
        }
    }
}
