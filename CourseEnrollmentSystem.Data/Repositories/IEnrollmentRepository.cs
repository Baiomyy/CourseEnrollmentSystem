using CourseEnrollmentSystem.Data.Entities;

namespace CourseEnrollmentSystem.Data.Repositories
{
    public interface IEnrollmentRepository
    {
        Task<IEnumerable<Enrollment>> GetAllAsync();
        Task<Enrollment> AddAsync(Enrollment enrollment);
        Task<bool> IsEnrolledAsync(int studentId, int courseId);
        Task<int> GetEnrollmentCountAsync(int courseId);
        Task<int> SaveChangesAsync();
    }
}

