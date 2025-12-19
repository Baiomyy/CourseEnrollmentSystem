using CourseEnrollmentSystem.Data.Entities;

namespace CourseEnrollmentSystem.Business.Interfaces
{
    public interface IEnrollmentService
    {
        Task<Enrollment> EnrollStudentAsync(int studentId, int courseId);
        Task<IEnumerable<Enrollment>> GetAllAsync();
    }
}

