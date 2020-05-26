using System;
using System.Collections.Generic;

namespace TestverktygAPI.Models
{
    public class Exam
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
        public virtual List<Question> Questions { get; set; } = new List<Question>();
        public virtual List<ExamQuestion> ExamQuestions { get; set; } = new List<ExamQuestion>();
        public virtual Class Class { get; set; }
    }
}
