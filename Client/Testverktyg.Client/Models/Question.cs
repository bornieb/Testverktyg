using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testverktyg.Client.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public int CourseId { get; set; }
        public
        public string QuestionText { get; set; }
        public QuestionType QuestionType { get; set; }
        public int QuestionValue { get; set; }
        public string StudentsFreeAnswer { get; set; }
        public List<Alternative> Alternatives { get; set; } = new List<Alternative>();
        public List<int> RightAnswers { get; set; } = new List<int>();
    }
}
