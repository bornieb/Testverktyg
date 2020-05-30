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
        public List<Exam> Exams { get; set; } = new List<Exam>();

        public void LoadData()
        {
            var examService = new ExamService();
            //examService.GetStudentExams()
        }
    }
}
