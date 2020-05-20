using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestverktygAPI.Models
{
    public class Keyword
    {
        public int KeywordId { get; set; }
        public string KeywordText { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}
