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
        public string Subject { get; set; }
        public int MaxAmountOfPoints { get; set; }
        public int NumberOfQuestions { get; set; }
        public int GradeScale { get; set; }
        public int CurrentQuestion { get; set; }
        public int ExamResult { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
    }
}
