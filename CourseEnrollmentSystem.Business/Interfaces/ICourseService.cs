using CourseEnrollmentSystem.Data.Entities;
using CourseEnrollmentSystem.Business.Results;

namespace CourseEnrollmentSystem.Business.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
        Task<Course> CreateAsync(Course course);
        Task<Result> UpdateAsync(Course course);
        Task<Result> DeleteAsync(int id);
        Task<int> GetAvailableSlotsAsync(int courseId);
        Task<PaginatedResult<Course>> GetAllPaginatedAsync(int pageNumber, int pageSize);
    }
}

