using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testverktyg.Client.Models;
using Testverktyg.Client.Services;

namespace Testverktyg.Client.ViewModels
{
    public class TeacherOverviewViewModel
    {
        ClassService classService  = new ClassService();
        public ObservableCollection<Class> ListOfClasses { get; set; } = new ObservableCollection<Class>();
        public ObservableCollection<Exam> TakenExams { get; set; } = new ObservableCollection<Exam>();
        ExamService examService = new ExamService();
        
        
        public async void GetClasses()
        {
            var classes = await classService.GetClassesAsync();
            foreach (Class sClass in classes)
            {
                ListOfClasses.Add(sClass);
            }
        }

        public void GetTakenExams(int classId)
        {
            TakenExams.Clear();
            var takenExams = examService.GetTakenExams(classId);
            foreach (Exam exam in takenExams)
            {
                TakenExams.Add(exam);
            }
        }


    }
}
