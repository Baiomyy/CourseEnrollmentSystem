using CourseEnrollmentSystem.Data.Entities;
using CourseEnrollmentSystem.Business.Results;

namespace CourseEnrollmentSystem.Business.Interfaces
{
    public interface IEnrollmentService
    {
        Task<Result> EnrollStudentAsync(int studentId, int courseId);
        Task<IEnumerable<Enrollment>> GetAllAsync();
    }
}

