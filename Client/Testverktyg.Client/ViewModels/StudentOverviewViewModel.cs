using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testverktyg.Client.Models;
using Testverktyg.Client.Services;


namespace Testverktyg.Client.ViewModels
{
    public class StudentOverviewViewModel
    {
        public Student myStudent
        {
            get;
            set;
        }

        StudentService studentService = new StudentService();

        public StudentOverviewViewModel()
        {
            myStudent = new Student(1,"Glenn", "Jönsson", "glennj83@hotmail.com", "glenn", 2);

            
            //Student myStudent1 = studentService.GetUserAsync(1);
        }


    }


}
