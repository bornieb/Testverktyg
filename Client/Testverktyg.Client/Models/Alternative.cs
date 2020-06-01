namespace Testverktyg.Client.Models
{
    public class Alternative
    {
        public int AlternativeId { get; set; }
        public string AlternativeText { get; set; }
        public int QuestionId { get; set; }
        public bool IsCorrect { get; set; }
        public bool StudentAnswer { get; set; }

        public Alternative(string alternative, bool isCorrect)
        {
            AlternativeText = alternative;
            IsCorrect = isCorrect;
        }
    }
}
