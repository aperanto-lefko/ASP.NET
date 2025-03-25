using Microsoft.EntityFrameworkCore;
using StudentPerformanceSystem.Models;

namespace StudentPerformanceSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Начальные данные для тестирования
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FirstName = "Иван",
                    LastName = "Иванов",
                    Group = "T521",
                    TaskPoints = 85,
                    TestPoints = 90,
                    ExamPoints = 80,
                    EnrollmentDate = new DateTime(2023, 1, 1)
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Петр",
                    LastName = "Петров",
                    Group = "g561",
                    TaskPoints = 75,
                    TestPoints = 80,
                    ExamPoints = 70,
                    EnrollmentDate = new DateTime(2023, 1, 1)
                }
            );
        }
    }
}

