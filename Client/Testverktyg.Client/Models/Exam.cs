using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Security.Cryptography.Core;

namespace Testverktyg.Client.Models
{
    public class Exam : INotifyPropertyChanged
    {
        public int ExamId { get; set; }
        public int ClassId { get; set; }
        public DateTime ExamDate { get; set; }
        public TimeSpan ExamTimeSpan { get; set; }
        public string Subject { get; set; }
        public int TotalPoints { get; set; }
        public int NumberOfQuestions { get; set; }
        public int GradeScale { get; set; }
        public int CurrentQuestion { get; set; }
        public int ExamResult { get; set; }
        public ExamStatus ExamStatus { get; set; }
        public ExamType ExamType { get; set; }
        public ObservableCollection<Question> Questions { get; set; } = new ObservableCollection<Question>();

        //public Exam(int examid,  int classid, string subject, int maxpoints, int numquestions, int grade, int currentq, int examresult)
        //{
        //    ExamId = examid;
        //    ClassId = classid;
        //    Subject = subject;
        //    MaxAmountOfPoints = maxpoints;
        //    NumberOfQuestions = numquestions;
        //    GradeScale = grade;
        //    CurrentQuestion = currentq;
        //    ExamResult = examresult;
        //    Questions = new List<Question>();
        //}

        public Exam()
        {

        }

        //string displayQtn = "";
        //string displayPts = "";
        //public string DisplayAmountOfQuestions { get { return $"Antal frågor: {NumberOfQuestions.ToString()}"; } set { displayQtn = value; NotifyPropertyChanged("DisplayAmountOfQuestions"); } }
        //public string DisplayTotalPoints { get { return $"Maxpoäng: {MaxAmountOfPoints}"; } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
    }
}
