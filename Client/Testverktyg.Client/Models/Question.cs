using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testverktyg.Client.Models
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
        public ObservableCollection<Alternative> Alternatives { get; } = new ObservableCollection<Alternative>();
        public ObservableCollection<Keyword> Keywords { get; } = new ObservableCollection<Keyword>();

        public Question()
        {

        }

        public void AddAlternative(string alternative, bool isCorrect)
        {
            Alternative alternative1 = new Alternative(alternative, isCorrect);
            Alternatives.Add(alternative1);
        }

        public void RemoveAlternative(Alternative alternative)
        {
            Alternatives.Remove(alternative);
        }

        public void AddKeyword(string keyword)
        {
            Keyword keyword1 = new Keyword(keyword);
            Keywords.Add(keyword1);
        }

        public void RemoveKeyword(Keyword keyword)
        {
            Keywords.Remove(keyword);
        }
    }
}
