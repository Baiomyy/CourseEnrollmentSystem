using CourseEnrollmentSystem.Data.Entities;
using CourseEnrollmentSystem.Business.Results;

namespace CourseEnrollmentSystem.Business.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
        Task<Student> CreateAsync(Student student);
        Task UpdateAsync(Student student);
        Task<Result> DeleteAsync(int id);
    }
}

