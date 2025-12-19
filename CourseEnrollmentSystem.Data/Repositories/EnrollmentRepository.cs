using Microsoft.EntityFrameworkCore;
using CourseEnrollmentSystem.Data.Contexts;
using CourseEnrollmentSystem.Data.Entities;

namespace CourseEnrollmentSystem.Data.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Enrollment>> GetAllAsync()
        {
            return await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .ToListAsync();
        }

        public async Task<Enrollment> AddAsync(Enrollment enrollment)
        {
            await _context.Enrollments.AddAsync(enrollment);
            return enrollment;
        }

        public async Task<bool> IsEnrolledAsync(int studentId, int courseId)
        {
            return await _context.Enrollments
                .AnyAsync(e => e.StudentId == studentId && e.CourseId == courseId);
        }

        public async Task<int> GetEnrollmentCountAsync(int courseId)
        {
            return await _context.Enrollments
                .CountAsync(e => e.CourseId == courseId);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

