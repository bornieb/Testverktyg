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
        private ExamService service = new ExamService();


        //public void LoadQuestions()
        //{
        //    _model = new StudentOverviewViewModel();
        //    _model.ExamsToBeTaken = new List<Question>();

        //    foreach (Question q in _model.ExamsToBeTaken)
        //    {

        //    }
        //}
        public async void SecureSubmit(Exam exam)
        {
            ContentDialog dialog = new ContentDialog();

            dialog.Title = "Lämna in prov";
            dialog.SecondaryButtonText = "Nej";
            dialog.PrimaryButtonText = "Ja";
            dialog.Content = "Är du säker?";
            var result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                CountTotalPoints(exam);
                await service.PostTakenExam(exam);
            }
            else if (result == ContentDialogResult.Secondary)
            {

            }
        }

        public void CountTotalPoints(Exam exam)
        {
            int checkPoint = 0;

            foreach (var question in exam.Questions)
            {
                foreach (var alternative in question.Alternatives)
                {
                    if (alternative.IsCorrect == alternative.StudentAnswer)
                    {
                        checkPoint++;
                    }
                }
                if (checkPoint == question.Alternatives.Count)
                {
                    exam.ExamResult++;
                }
            }
        }

    }
}
