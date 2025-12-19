using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseEnrollmentSystem.Data.Entities;

namespace CourseEnrollmentSystem.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            // Email - Unique Index (cannot be done with Data Annotations alone)
            builder.HasIndex(s => s.Email)
                .IsUnique();

            // Configure relationship with Enrollment (requires Fluent API)
            builder.HasMany(s => s.Enrollments)
                .WithOne(e => e.Student)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

