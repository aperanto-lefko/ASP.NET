using StudentPerformanceSystem.Models;

namespace StudentPerformanceSystem.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);
        Task AddAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(int id);
        Task<IEnumerable<Student>> GetTopStudentsAsync(int count);
        Task<IEnumerable<Student>> GetWorstStudentsAsync(int count);
    }
}
