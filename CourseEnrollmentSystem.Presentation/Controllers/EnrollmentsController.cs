using Microsoft.AspNetCore.Mvc;
using CourseEnrollmentSystem.Business.Interfaces;
using CourseEnrollmentSystem.Data.Entities;
using CourseEnrollmentSystem.Presentation.ViewModels;
using CourseEnrollmentSystem.Presentation.Mappings;
using CourseEnrollmentSystem.Business.Results;

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
            var students = await _studentService.GetAllAsync();
            var courses = await _courseService.GetAllAsync();
            var viewModel = EnrollmentMapper.ToViewModel(students, courses);
            return View(viewModel);
        }

        // POST: Enrollments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EnrollmentCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _enrollmentService.EnrollStudentAsync(viewModel.StudentId, viewModel.CourseId);
                if (!result.IsSuccess)
                {
                    ModelState.AddModelError("", result.ErrorMessage ?? "An error occurred.");
                    // Reload dropdowns on error
                    var students = await _studentService.GetAllAsync();
                    var courses = await _courseService.GetAllAsync();
                    viewModel = EnrollmentMapper.ToViewModel(students, courses);
                    return View(viewModel);
                }
                return RedirectToAction(nameof(Index));
            }

            // Reload dropdowns on validation error
            var studentsReload = await _studentService.GetAllAsync();
            var coursesReload = await _courseService.GetAllAsync();
            viewModel = EnrollmentMapper.ToViewModel(studentsReload, coursesReload);
            return View(viewModel);
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

