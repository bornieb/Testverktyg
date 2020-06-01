using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testverktyg.Client.Services;
using Testverktyg.Client.Models;
using System.ServiceModel.Description;
using Windows.UI.Popups;

namespace Testverktyg.Client.ViewModels
{
    class TakeExamViewModel
    {
        public StudentOverviewViewModel _model = new StudentOverviewViewModel();
        

        //public void LoadQuestions()
        //{
        //    _model = new StudentOverviewViewModel();
        //    _model.ExamsToBeTaken = new List<Question>();
            
        //    foreach (Question q in _model.ExamsToBeTaken)
        //    {

        //    }
        //}
        
        

    }
}
