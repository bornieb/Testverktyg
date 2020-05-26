using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testverktyg.Client.Models;


namespace Testverktyg.Client.ViewModels
{
    class StudentOverviewViewModel
    {
        public Student myStudent
        {
            get;
            set;
        }


        public StudentOverviewViewModel()
        {
            myStudent = new Student(1,"Glenn", "Jönsson", "glennj83@hotmail.com", "glenn", 2);
        }


    }


}
