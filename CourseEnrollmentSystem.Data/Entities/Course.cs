using System.ComponentModel.DataAnnotations;

namespace CourseEnrollmentSystem.Data.Entities
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string? Description { get; set; }

        [Required]
        public int MaxCapacity { get; set; }

        // Navigation property for enrollments
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}

