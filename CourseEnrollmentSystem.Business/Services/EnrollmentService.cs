using CourseEnrollmentSystem.Data.Entities;
using CourseEnrollmentSystem.Data.Repositories;
using CourseEnrollmentSystem.Business.Interfaces;

namespace CourseEnrollmentSystem.Business.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseService _courseService;

        public EnrollmentService(
            IEnrollmentRepository enrollmentRepository,
            IStudentRepository studentRepository,
            ICourseRepository courseRepository,
            ICourseService courseService)
        {
            _enrollmentRepository = enrollmentRepository;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _courseService = courseService;
        }

        public async Task<Enrollment> EnrollStudentAsync(int studentId, int courseId)
        {
            // Validate student exists
            var student = await _studentRepository.GetByIdAsync(studentId);
            if (student == null)
            {
                throw new ArgumentException($"Student with ID {studentId} not found.");
            }

            // Validate course exists
            var course = await _courseRepository.GetByIdAsync(courseId);
            if (course == null)
            {
                throw new ArgumentException($"Course with ID {courseId} not found.");
            }

            // Prevent duplicate enrollment
            if (await _enrollmentRepository.IsEnrolledAsync(studentId, courseId))
            {
                throw new InvalidOperationException($"Student is already enrolled in this course.");
            }

            // Prevent enrollment if course is full
            var availableSlots = await _courseService.GetAvailableSlotsAsync(courseId);
            if (availableSlots <= 0)
            {
                throw new InvalidOperationException($"Course is full. No available slots.");
            }

            // Create enrollment
            var enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId
            };

            await _enrollmentRepository.AddAsync(enrollment);
            await _enrollmentRepository.SaveChangesAsync();

            return enrollment;
        }

        public async Task<IEnumerable<Enrollment>> GetAllAsync()
        {
            return await _enrollmentRepository.GetAllAsync();
        }
    }
}

