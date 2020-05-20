using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

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
        public ObservableCollection<Alternative> Alternatives { get; set; } = new ObservableCollection<Alternative>();
        public List<int> RightAnswers { get; set; } = new List<int>();
        public ObservableCollection<Keyword> Keywords { get; set; } = new ObservableCollection<Keyword>();

    }
}
