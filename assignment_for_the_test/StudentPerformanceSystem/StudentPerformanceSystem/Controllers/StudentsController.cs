using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPerformanceSystem.Data;
using StudentPerformanceSystem.Models;
using StudentPerformanceSystem.Service;
using System.Text;

namespace StudentPerformanceSystem.Controllers
{
   
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return View(students.OrderByDescending(s => s.TotalPoints));
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentService.GetStudentByIdAsync(id.Value);
            return student == null ? NotFound() : View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Group,TaskPoints,TestPoints,ExamPoints")] Student student)
        {
            if (ModelState.IsValid)
            {
                await _studentService.CreateStudentAsync(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentService.GetStudentByIdAsync(id.Value);
            return student == null ? NotFound() : View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Group,TaskPoints,TestPoints,ExamPoints")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _studentService.UpdateStudentAsync(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentService.GetStudentByIdAsync(id.Value);
            return student == null ? NotFound() : View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _studentService.DeleteStudentAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Students/TopStudents
        public async Task<IActionResult> TopStudents()
        {
            return View(await _studentService.GetTopStudentsAsync(5));
        }

        // GET: Students/WorstStudents
        public async Task<IActionResult> WorstStudents()
        {
            return View(await _studentService.GetWorstStudentsAsync(5));
        }

        // GET: Students/ExportToText
        [HttpGet("/Students/ExportToText")]
        public async Task<IActionResult> ExportStudentsToText()
        {
            var report = await _studentService.GenerateStudentReportAsync();
            return File(Encoding.UTF8.GetBytes(report), "text/plain", "students_results.txt");
        }
    }
}
