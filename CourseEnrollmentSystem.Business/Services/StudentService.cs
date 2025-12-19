using CourseEnrollmentSystem.Data.Entities;
using CourseEnrollmentSystem.Data.Repositories;
using CourseEnrollmentSystem.Business.Interfaces;
using CourseEnrollmentSystem.Business.Results;

namespace CourseEnrollmentSystem.Business.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task<Student> CreateAsync(Student student)
        {
            // Business logic validation can be added here
            // For now, just add and save
            var addedStudent = await _studentRepository.AddAsync(student);
            await _studentRepository.SaveChangesAsync();
            return addedStudent;
        }

        public async Task UpdateAsync(Student student)
        {
            // Business logic validation can be added here
            await _studentRepository.UpdateAsync(student);
            await _studentRepository.SaveChangesAsync();
        }

        public async Task<Result> DeleteAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                return Result.Failure($"Student with ID {id} not found.");
            }
                
            await _studentRepository.DeleteAsync(student);
            await _studentRepository.SaveChangesAsync();
            return Result.Success();
        }
    }
}

