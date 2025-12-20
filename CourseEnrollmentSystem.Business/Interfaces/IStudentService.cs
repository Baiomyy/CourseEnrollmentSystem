using CourseEnrollmentSystem.Data.Entities;
using CourseEnrollmentSystem.Business.Results;

namespace CourseEnrollmentSystem.Business.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
        Task<Result> CreateAsync(Student student);
        Task<Result> UpdateAsync(Student student);
        Task<Result> DeleteAsync(int id);
    }
}

