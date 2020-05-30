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
        public List<Exam> Exams { get; set; } = new List<Exam>();

        public void LoadData()
        {
            var examService = new ExamService();
            //examService.GetStudentExams()
        }
        
        private static StudentOverviewViewModel instance;
        public Exam exam { get; set; }
        public ObservableCollection<Exam> AllExams;

        public static StudentOverviewViewModel Instance
        { get { if (instance == null)
                    instance = new StudentOverviewViewModel();
                return instance;
              }

        }
        private StudentOverviewViewModel()
        {
            exam = new Exam();
            AllExams = new ObservableCollection<Exam>();
            //GetExams();
        }
      public async void GetExams()
        {
            try
            {
                List<Exam> temp = await ExamService.GetExamAsync();
                foreach (Exam exam in temp)
                {
                    AllExams.Add(exam);
                }
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                await new MessageDialog(ex.Message).ShowAsync();
            }
        }
    }
}
