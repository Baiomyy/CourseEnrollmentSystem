using CourseEnrollmentSystem.Data.Entities;

namespace CourseEnrollmentSystem.Business.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
        Task<Course> CreateAsync(Course course);
        Task UpdateAsync(Course course);
        Task DeleteAsync(int id);
        Task<int> GetAvailableSlotsAsync(int courseId);
    }
}

