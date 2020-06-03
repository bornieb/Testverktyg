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
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Testverktyg.Client.ViewModels
{
    public class TakeExamViewModel
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
        public async void SecureSubmit()
        {
            ContentDialog dialog = new ContentDialog();

            dialog.Title = "Lämna in prov";
            dialog.SecondaryButtonText = "Nej";
            dialog.PrimaryButtonText = "Ja";
            dialog.Content = "Är du säker?";
            var result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {

            }
            else if (result == ContentDialogResult.Secondary)
            {

            }
        }

    }
}
