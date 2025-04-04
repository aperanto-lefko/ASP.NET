﻿using StudentPerformanceSystem.Models;
using StudentPerformanceSystem.Repository;


namespace StudentPerformanceSystem.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        //private readonly IReportGenerator _reportGenerator;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
            => await _repository.GetAllAsync();

        public async Task<Student> GetStudentByIdAsync(int id)
            => await _repository.GetByIdAsync(id);

        public async Task CreateStudentAsync(Student student)
            => await _repository.AddAsync(student);

        public async Task UpdateStudentAsync(Student student)
            => await _repository.UpdateAsync(student);

        public async Task DeleteStudentAsync(int id)
            => await _repository.DeleteAsync(id);

        public async Task<IEnumerable<Student>> GetTopStudentsAsync(int count)
            => await _repository.GetTopStudentsAsync(count);

        public async Task<IEnumerable<Student>> GetWorstStudentsAsync(int count)
            => await _repository.GetWorstStudentsAsync(count);

    }
}
