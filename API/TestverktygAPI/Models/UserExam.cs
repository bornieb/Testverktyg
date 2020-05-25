namespace TestverktygAPI.Models
{
    public class UserExam
    {
        public int UserId { get; set; }
        public int ExamId { get; set; }
        public User User { get; set; }
        public Exam Exam { get; set; }
    }
}
