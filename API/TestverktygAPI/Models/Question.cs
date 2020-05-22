using System.Collections.Generic;

namespace TestverktygAPI.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public int CourseId { get; set; }
        public GradeLevel GradeLevel { get; set; }
        public string QuestionText { get; set; }
        public QuestionType QuestionType { get; set; }
        public int QuestionValue { get; set; }
        public string StudentsFreeAnswer { get; set; }
        public List<Alternative> Alternatives { get; set; } = new List<Alternative>();
        public List<Keyword> Keywords { get; set; } = new List<Keyword>();

    }
}
