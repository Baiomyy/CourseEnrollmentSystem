using CourseEnrollmentSystem.Business.Interfaces;
using CourseEnrollmentSystem.Data.Entities;
using CourseEnrollmentSystem.Data.Repositories;
using CourseEnrollmentSystem.Business.Results;

namespace CourseEnrollmentSystem.Business.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly IEnrollmentRepository _enrollmentRepository;

    public CourseService(
        ICourseRepository courseRepository,
        IEnrollmentRepository enrollmentRepository)
    {
        _courseRepository = courseRepository;
        _enrollmentRepository = enrollmentRepository;
    }

    public async Task<Course> CreateAsync(Course course)
    {
        var addedCourse = await _courseRepository.AddAsync(course);
        await _courseRepository.SaveChangesAsync();
        return addedCourse;
    }

    public async Task<Result> DeleteAsync(int id)
    {
        var course = await _courseRepository.GetByIdAsync(id);
        if (course == null)
        {
            return Result.Failure($"Course with ID {id} not found.");
        }

        await _courseRepository.DeleteAsync(course);
        await _courseRepository.SaveChangesAsync();
        return Result.Success();
    }

    public async Task<IEnumerable<Course>> GetAllAsync()
    {
        return await _courseRepository.GetAllAsync();
    }

    public async Task<int> GetAvailableSlotsAsync(int courseId)
    {
        var course = await _courseRepository.GetByIdAsync(courseId);
        if (course == null)
        {
            throw new ArgumentException($"Course with ID {courseId} not found.");
        }

        var enrollmentCount = await _enrollmentRepository.GetEnrollmentCountAsync(courseId);
        return course.MaxCapacity - enrollmentCount;
    }

    public async Task<Course?> GetByIdAsync(int id)
    {
        return await _courseRepository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(Course course)
    {
        await _courseRepository.UpdateAsync(course);
        await _courseRepository.SaveChangesAsync();
    }
}
