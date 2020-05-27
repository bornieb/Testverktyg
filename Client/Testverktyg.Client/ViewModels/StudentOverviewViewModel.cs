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
            myStudent.Exams.Add(new Exam(1, 7, "Provdatum 20200524", "1 tim" ,"Engelska", 25, 25, 5, 4, 10, ExamStatus.NotTaken, ExamType.RegularExam ));
            myStudent.Exams.Add(new Exam(1, 8, "Provdatum 20200528", "1,5 tim" ,"Svenska", 25, 25, 5, 4, 10, ExamStatus.Corrected, ExamType.RegularExam));
            myStudent.Exams.Add(new Exam(1, 9, "Provdatum 20200528", "1,5 tim", "Matematik", 25, 25, 5, 4, 10, ExamStatus.Taken, ExamType.DiagnosticExam));
            myStudent.Exams.Add(new Exam(1, 7, "Provdatum 20200528", "1 tim", "C# .Net Framework", 25, 25, 5, 4, 10, ExamStatus.Taken, ExamType.DiagnosticExam));

            //ListOfStudents.Add(new Student(1, "Glenn", "Jönsson", "glennemannen@hotmail.com", "hejsan", 1));
            //ListOfStudents.Add(new Student(2, "Eric", "Hedin", "eric@hotmail.com", "hejsan", 2));

            //Student myStudent1 = studentService.GetUserAsync(1);
        }


    }


}
