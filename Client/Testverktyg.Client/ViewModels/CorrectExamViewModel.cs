using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testverktyg.Client.Services;
using Testverktyg.Client.Models;

namespace Testverktyg.Client.ViewModels
{
    class CorrectExamViewModel
    {
        ExamService examService;
        public ObservableCollection<Exam> ListOfExams = new ObservableCollection<Exam>();
        public CorrectExamViewModel()
        {
                examService = new ExamService();
        }

        public async void GetExams()
        {
            var exams = await examService.GetExam();
            foreach (var item in exams)
            {
                ListOfExams.Add(item);
            }
        }
    }
}
