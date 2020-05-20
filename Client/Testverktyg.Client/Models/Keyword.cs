using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testverktyg.Client.Models
{
    public class Keyword
    {
        public int KeywordId { get; set; }
        public string KeywordText { get; set; }
        public int QuestionId { get; set; }

        public Keyword(string keyword)
        {
            KeywordText = keyword;
        }
    }
}
