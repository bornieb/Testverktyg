using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testverktyg.Client.Models
{
    public class Exam
    {
        public int ExamId { get; set; }
        public DateTime StartExamDate { get; set; }
        public DateTime EndExamDate { get; set; }
        public int ClassId { get; set; }
        public string Subject { get; set; }
        public int MaxAmountOfPoints { get; set; }
        public int NumberOfQuestions { get; set; }
        public int GradeScale { get; set; }
        public int CurrentQuestion { get; set; }
        public int ExamResult { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();

        public Exam(int examid, DateTime startdate, DateTime enddate, int classid, string subject, int maxpoints, int numquestions, int grade, int currentq, int examresult)
        {
            ExamId = examid;
            StartExamDate = startdate;
            EndExamDate = enddate;
            ClassId = classid;
            Subject = subject;
            MaxAmountOfPoints = maxpoints;
            NumberOfQuestions = numquestions;
            GradeScale = grade;
            CurrentQuestion = currentq;
            ExamResult = examresult;
            Questions = new List<Question>();
        }
    }
}
