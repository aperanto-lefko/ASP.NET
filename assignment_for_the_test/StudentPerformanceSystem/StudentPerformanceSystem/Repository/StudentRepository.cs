﻿using Microsoft.EntityFrameworkCore;
using StudentPerformanceSystem.Data;
using StudentPerformanceSystem.Models;


namespace StudentPerformanceSystem.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
            => await _context.Students.ToListAsync();

        public async Task<Student> GetByIdAsync(int id)
            => await _context.Students.FindAsync(id);

        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await GetByIdAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Student>> GetTopStudentsAsync(int count)
            => await _context.Students
                .OrderByDescending(s => s.TaskPoints + s.TestPoints + s.ExamPoints)
                .Take(count)
                .ToListAsync();

        public async Task<IEnumerable<Student>> GetWorstStudentsAsync(int count)
            => await _context.Students
                .OrderBy(s => s.TaskPoints + s.TestPoints + s.ExamPoints)
                .Take(count)
                .ToListAsync();
    }
}
