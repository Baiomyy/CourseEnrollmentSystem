using CourseEnrollmentSystem.Presentation.ViewModels;
using CourseEnrollmentSystem.Data.Entities;

namespace CourseEnrollmentSystem.Presentation.Mappings
{
    public static class EnrollmentMapper
    {
        public static EnrollmentCreateViewModel ToViewModel(
            IEnumerable<Student> students,
            IEnumerable<Course> courses)
        {
            return new EnrollmentCreateViewModel
            {
                Students = students.Select(s => new StudentOption
                {
                    Id = s.Id,
                    FullName = s.FullName,
                    Email = s.Email
                }).ToList(),
                Courses = courses.Select(c => new CourseOption
                {
                    Id = c.Id,
                    Title = c.Title
                }).ToList()
            };
        }
    }
}

