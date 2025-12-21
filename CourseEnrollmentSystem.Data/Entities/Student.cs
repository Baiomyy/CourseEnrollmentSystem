using System.ComponentModel.DataAnnotations;
using CourseEnrollmentSystem.Data.Attributes;

namespace CourseEnrollmentSystem.Data.Entities
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [NotFutureDate(ErrorMessage = "Birthdate cannot be in the future")]
        public DateTime Birthdate { get; set; }

        [Required]
        [MaxLength(14)]
        [RegularExpression(@"^\d+$", ErrorMessage = "National ID must contain digits only")]
        public string NationalId { get; set; } = string.Empty;

        [MaxLength(11)]
        [RegularExpression(@"^\d*$", ErrorMessage = "Phone number must contain digits only")]
        public string? PhoneNumber { get; set; }

        // Navigation property for enrollments
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}

