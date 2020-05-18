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
        public string AlternativeText { get; set; }
        public int QuestionId { get; set; }

    }
}
