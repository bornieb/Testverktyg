namespace TestverktygAPI.Models
{
    public class Student : User
    {
        public int ClassId { get; set; }
        public virtual Class Class { get; set; }
    }
}
