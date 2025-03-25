using StudentPerformanceSystem.Models;

namespace StudentPerformanceSystem.Service
{
    public interface IReportGenerator
    {
        Task<string> GenerateStudentReportAsync(IEnumerable<Student> students);
    }
}
