using StudentPerformanceSystem.Models;
using System.Text;

namespace StudentPerformanceSystem.Service
{
    public class TextReportGenerator : IReportGenerator
    {
        public Task<string> GenerateStudentReportAsync(IEnumerable<Student> students)
        {
            if (students == null || !students.Any())
                throw new ArgumentException("Список студентов пуст");

            var sb = new StringBuilder();

            sb.AppendLine("Отчёт по студентам");
            sb.AppendLine($"Дата формирования: {DateTime.Now:dd.MM.yyyy HH:mm}");
            sb.AppendLine(new string('-', 50));
            sb.AppendLine();

            foreach (var student in students.OrderBy(s => s.LastName))
            {
                sb.AppendLine($"ФИО: {student.LastName} {student.FirstName}");
                sb.AppendLine($"Группа: {student.Group}");
                sb.AppendLine($"Баллы:");
                sb.AppendLine($"  Задания: {student.TaskPoints}");
                sb.AppendLine($"  Тесты: {student.TestPoints}");
                sb.AppendLine($"  Экзамен: {student.ExamPoints}");
                sb.AppendLine($"Итого: {student.TotalPoints} баллов");
                sb.AppendLine(new string('-', 30));
            }

            sb.AppendLine();
            sb.AppendLine($"Всего студентов: {students.Count()}");
            sb.AppendLine($"Средний балл: {students.Average(s => s.TotalPoints):F2}");

            return Task.FromResult(sb.ToString());
        }
    }
}
