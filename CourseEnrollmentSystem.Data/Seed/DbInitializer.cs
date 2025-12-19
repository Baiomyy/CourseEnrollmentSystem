using CourseEnrollmentSystem.Data.Contexts;
using CourseEnrollmentSystem.Data.Entities;

namespace CourseEnrollmentSystem.Data.Seed
{
    public static class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            // Ensure database is created
            context.Database.EnsureCreated();

            // Check if data already exists
            if (context.Students.Any() || context.Courses.Any())
            {
                return; // Database has been seeded
            }

            // Seed Students
            var students = new List<Student>
            {
                new Student
                {
                    FullName = "Ahmed Mohamed",
                    Email = "ahmed.mohamed@email.com",
                    Birthdate = new DateTime(2000, 5, 15),
                    NationalId = "12345678901234",
                    PhoneNumber = "01234567890"
                },
                new Student
                {
                    FullName = "Sara Ali",
                    Email = "sara.ali@email.com",
                    Birthdate = new DateTime(2001, 8, 20),
                    NationalId = "23456789012345",
                    PhoneNumber = "01123456789"
                },
                new Student
                {
                    FullName = "Mohamed Hassan",
                    Email = "mohamed.hassan@email.com",
                    Birthdate = new DateTime(1999, 3, 10),
                    NationalId = "34567890123456",
                    PhoneNumber = "01012345678"
                },
                new Student
                {
                    FullName = "Fatma Ibrahim",
                    Email = "fatma.ibrahim@email.com",
                    Birthdate = new DateTime(2002, 11, 5),
                    NationalId = "45678901234567",
                    PhoneNumber = "01512345678"
                },
                new Student
                {
                    FullName = "Omar Khaled",
                    Email = "omar.khaled@email.com",
                    Birthdate = new DateTime(2000, 7, 25),
                    NationalId = "56789012345678",
                    PhoneNumber = null // Optional field
                }
            };

            context.Students.AddRange(students);

            // Seed Courses
            var courses = new List<Course>
            {
                new Course
                {
                    Title = "Introduction to Programming",
                    Description = "Learn the fundamentals of programming with C#",
                    MaxCapacity = 30
                },
                new Course
                {
                    Title = "Database Design",
                    Description = "Design and implement relational databases",
                    MaxCapacity = 25
                },
                new Course
                {
                    Title = "Web Development",
                    Description = "Build modern web applications using ASP.NET MVC",
                    MaxCapacity = 20
                },
                new Course
                {
                    Title = "Software Engineering",
                    Description = "Principles and practices of software development",
                    MaxCapacity = 35
                },
                new Course
                {
                    Title = "Data Structures and Algorithms",
                    Description = "Essential data structures and algorithm design",
                    MaxCapacity = 28
                }
            };

            context.Courses.AddRange(courses);

            // Save all changes
            context.SaveChanges();
        }
    }
}

