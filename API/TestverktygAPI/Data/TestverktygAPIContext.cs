using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestverktygAPI.Models;

namespace TestverktygAPI.Data
{
    public class TestverktygAPIContext : DbContext
    {
        public TestverktygAPIContext (DbContextOptions<TestverktygAPIContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.CourseExam>().HasKey(sc => new { sc.CourseId, sc.ExamId });
            modelBuilder.Entity<Models.CourseQuestion>().HasKey(sc => new { sc.CourseId, sc.QuestionId });
            modelBuilder.Entity<Models.ExamQuestion>().HasKey(sc => new { sc.ExamId, sc.QuestionId });
            modelBuilder.Entity<Models.UserExam>().HasKey(sc => new { sc.UserId, sc.ExamId });
        }

        public DbSet<TestverktygAPI.Models.Alternative> Alternative { get; set; }

        public DbSet<TestverktygAPI.Models.Class> Class { get; set; }

        public DbSet<TestverktygAPI.Models.Course> Course { get; set; }

        public DbSet<TestverktygAPI.Models.Exam> Exam { get; set; }

        public DbSet<TestverktygAPI.Models.Keyword> Keyword { get; set; }

        public DbSet<TestverktygAPI.Models.Question> Question { get; set; }

        public DbSet<TestverktygAPI.Models.Student> Student { get; set; }

        public DbSet<TestverktygAPI.Models.Teacher> Teacher { get; set; }

        public DbSet<TestverktygAPI.Models.User> User { get; set; }
    }
}
