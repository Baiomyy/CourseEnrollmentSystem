using CourseEnrollmentSystem.Data.Entities;

namespace CourseEnrollmentSystem.Data.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
        Task<Course> AddAsync(Course course);
        Task UpdateAsync(Course course);
        Task DeleteAsync(Course course);
        Task<int> GetCountAsync();
        Task<IEnumerable<Course>> GetPaginatedAsync(int pageNumber, int pageSize);
        Task<int> SaveChangesAsync();
    }
}

