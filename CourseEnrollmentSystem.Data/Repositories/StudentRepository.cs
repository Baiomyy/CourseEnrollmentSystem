using Microsoft.EntityFrameworkCore;
using CourseEnrollmentSystem.Data.Contexts;
using CourseEnrollmentSystem.Data.Entities;

namespace CourseEnrollmentSystem.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<Student?> GetByEmailAsync(string email)
        {
            return await _context.Students
                .FirstOrDefaultAsync(s => s.Email == email);
        }

        public async Task<Student> AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            return student;
        }

        public async Task UpdateAsync(Student student)
        {
            var existingStudent = await _context.Students.FindAsync(student.Id);
            if (existingStudent == null)
            {
                throw new ArgumentException($"Student with ID {student.Id} not found.");
            }

            // Update only scalar properties (not navigation properties)
            existingStudent.FullName = student.FullName;
            existingStudent.Email = student.Email;
            existingStudent.Birthdate = student.Birthdate;
            existingStudent.NationalId = student.NationalId;
            existingStudent.PhoneNumber = student.PhoneNumber;
            
            // No need to call Update() - EF Core tracks changes automatically
        }

        public Task DeleteAsync(Student student)
        {
            _context.Students.Remove(student);
            return Task.CompletedTask;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

