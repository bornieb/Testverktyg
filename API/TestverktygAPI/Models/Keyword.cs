using System.Text.Json.Serialization;

namespace TestverktygAPI.Models
{
    public class Keyword
    {
        public int KeywordId { get; set; }
        public string KeywordText { get; set; }
        public int QuestionId { get; set; }
        [JsonIgnore]
        public virtual Question Question { get; set; }
    }
}
