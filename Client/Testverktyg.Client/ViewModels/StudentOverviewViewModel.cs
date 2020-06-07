using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testverktyg.Client.Models;
using Testverktyg.Client.Services;
using Windows.UI.Popups;

namespace Testverktyg.Client.ViewModels
{
    public class StudentOverviewViewModel
    {
        public Student Student { get; set; }
        public List<Exam> ExamsToBeTaken { get; set; } = new List<Exam>();
        public List<Exam> CorrectedExams { get; set; } = new List<Exam>();
        //public List<Exam> TakenExams { get; set; } = new List<Exam>();
        public StudentOverviewViewModel()
        {
        }

        public void LoadData(Student student)
        {
            Student = student;
            var examService = new ExamService();
            ExamsToBeTaken = examService.GetStudentExams(Student.UserId, ExamStatus.Template);
            CorrectedExams = examService.GetStudentExams(Student.UserId, ExamStatus.Corrected);
            //TakenExams = examService.GetStudentExams(Student.UserId, ExamStatus.Taken);
        }
    }
}
