using Microsoft.AspNetCore.Mvc;
using CourseEnrollmentSystem.Business.Interfaces;
using CourseEnrollmentSystem.Data.Entities;
using CourseEnrollmentSystem.Business.Results;

namespace CourseEnrollmentSystem.Presentation.Controllers
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
            var students = await _studentService.GetAllAsync();
            return View(students);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                var result = await _studentService.CreateAsync(student);
                if (!result.IsSuccess)
                {
                    ModelState.AddModelError("Email", result.ErrorMessage ?? "An error occurred.");
                    return View(student);
                }
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

            var student = await _studentService.GetByIdAsync(id.Value);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await _studentService.UpdateAsync(student);
                if (!result.IsSuccess)
                {
                    ModelState.AddModelError("Email", result.ErrorMessage ?? "An error occurred.");
                    return View(student);
                }
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

            var student = await _studentService.GetByIdAsync(id.Value);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _studentService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

