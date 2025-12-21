using System.ComponentModel.DataAnnotations;

namespace CourseEnrollmentSystem.Presentation.ViewModels
{
    public class EnrollmentCreateViewModel
    {
        [Required(ErrorMessage = "Student is required")]
        [Display(Name = "Student")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Course is required")]
        [Display(Name = "Course")]
        public int CourseId { get; set; }

        public List<StudentOption> Students { get; set; } = new();
        public List<CourseOption> Courses { get; set; } = new();
    }

    public class StudentOption
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    public class CourseOption
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}

