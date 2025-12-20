using CourseEnrollmentSystem.Data.Entities;
using CourseEnrollmentSystem.Data.Repositories;
using CourseEnrollmentSystem.Business.Interfaces;
using CourseEnrollmentSystem.Business.Results;

namespace CourseEnrollmentSystem.Business.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;

        public StudentService(
            IStudentRepository studentRepository,
            IEnrollmentRepository enrollmentRepository)
        {
            _studentRepository = studentRepository;
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task<Result> CreateAsync(Student student)
        {
            // Check if email already exists
            var existingStudent = await _studentRepository.GetByEmailAsync(student.Email);
            if (existingStudent != null)
            {
                return Result.Failure($"A student with email '{student.Email}' already exists.");
            }

            var addedStudent = await _studentRepository.AddAsync(student);
            await _studentRepository.SaveChangesAsync();
            return Result.Success();
        }

        public async Task<Result> UpdateAsync(Student student)
        {
            // Check if email already exists for a different student
            var existingStudent = await _studentRepository.GetByEmailAsync(student.Email);
            if (existingStudent != null && existingStudent.Id != student.Id)
            {
                return Result.Failure($"A student with email '{student.Email}' already exists.");
            }

            await _studentRepository.UpdateAsync(student);
            await _studentRepository.SaveChangesAsync();
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                return Result.Failure($"Student with ID {id} not found.");
            }
            
            // Manually delete enrollments (since In-Memory DB doesn't cascade)
            await _enrollmentRepository.DeleteByStudentIdAsync(id);
            
            // Delete student
            await _studentRepository.DeleteAsync(student);
            
            // Single SaveChanges - commits all changes atomically
            await _studentRepository.SaveChangesAsync();
            return Result.Success();
        }
    }
}

