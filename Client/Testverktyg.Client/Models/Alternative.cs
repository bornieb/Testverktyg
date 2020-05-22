using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testverktyg.Client.Models
{
    public class Alternative
    {
        public int AlternativeId { get; set; }
        public string AlternativeText { get; }
        public int QuestionId { get; set; }
        public bool IsCorrect { get; }

        public Alternative(string alternative, bool isCorrect)
        {
            AlternativeText = alternative;
            IsCorrect = isCorrect;
        }
    }
}
