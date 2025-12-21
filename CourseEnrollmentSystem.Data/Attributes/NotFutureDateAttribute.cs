using System.ComponentModel.DataAnnotations;

namespace CourseEnrollmentSystem.Data.Attributes
{
    public class NotFutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
                return true; // Let Required attribute handle null values

            if (value is DateTime dateValue)
            {
                return dateValue <= DateTime.Today;
            }

            return false;
        }
    }
}

