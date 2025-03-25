using StudentPerformanceSystem.Models;

namespace StudentPerformanceSystem.Service
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task CreateStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(int id);
        Task<IEnumerable<Student>> GetTopStudentsAsync(int count);
        Task<IEnumerable<Student>> GetWorstStudentsAsync(int count);
        Task<string> GenerateStudentReportAsync();
    }
}
