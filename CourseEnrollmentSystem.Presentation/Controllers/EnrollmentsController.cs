using Microsoft.AspNetCore.Mvc;
using CourseEnrollmentSystem.Business.Interfaces;
using CourseEnrollmentSystem.Data.Entities;

namespace CourseEnrollmentSystem.Presentation.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;

        public EnrollmentsController(
            IEnrollmentService enrollmentService,
            IStudentService studentService,
            ICourseService courseService)
        {
            _enrollmentService = enrollmentService;
            _studentService = studentService;
            _courseService = courseService;
        }

        // GET: Enrollments
        public async Task<IActionResult> Index()
        {
            var enrollments = await _enrollmentService.GetAllAsync();
            return View(enrollments);
        }

        // GET: Enrollments/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Students = await _studentService.GetAllAsync();
            ViewBag.Courses = await _courseService.GetAllAsync();
            return View();
        }

        // POST: Enrollments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int studentId, int courseId)
        {
            if (ModelState.IsValid)
            {
                var result = await _enrollmentService.EnrollStudentAsync(studentId, courseId);
                if (!result.IsSuccess)
                {
                    ModelState.AddModelError("", result.ErrorMessage ?? "An error occurred.");
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            ViewBag.Students = await _studentService.GetAllAsync();
            ViewBag.Courses = await _courseService.GetAllAsync();
            return View();
        }

        // GET: Enrollments/GetAvailableSlots
        // AJAX endpoint for dynamic available slots display
        [HttpGet]
        public async Task<IActionResult> GetAvailableSlots(int courseId)
        {
            try
            {
                var availableSlots = await _courseService.GetAvailableSlotsAsync(courseId);
                return Json(new { availableSlots = availableSlots });
            }
            catch (ArgumentException ex)
            {
                return Json(new { error = ex.Message });
            }
        }
    }
}

