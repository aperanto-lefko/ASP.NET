using System.ComponentModel.DataAnnotations;

namespace StudentPerformanceSystem.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Имя обязательно")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Фамилия обязательна")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Группа обязательна")]
        [Display(Name = "Группа")]
        public string Group { get; set; }

        [Range(0, 100, ErrorMessage = "Баллы должны быть от 0 до 100")]
        [Display(Name = "Баллы за задания")]
        public int TaskPoints { get; set; }

        [Range(0, 100, ErrorMessage = "Баллы должны быть от 0 до 100")]
        [Display(Name = "Баллы за тесты")]
        public int TestPoints { get; set; }

        [Range(0, 100, ErrorMessage = "Баллы должны быть от 0 до 100")]
        [Display(Name = "Баллы за экзамен")]
        public int ExamPoints { get; set; }

        [Display(Name = "Сумма баллов")]
        public int TotalPoints => TaskPoints + TestPoints + ExamPoints;

        [Display(Name = "Дата добавления")]
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;
    }
}

