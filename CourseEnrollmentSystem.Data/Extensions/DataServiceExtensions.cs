using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CourseEnrollmentSystem.Data.Contexts;
using CourseEnrollmentSystem.Data.Repositories;

namespace CourseEnrollmentSystem.Data.Extensions
{
    public static class DataServiceExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            // Configure Entity Framework Core with In-Memory Database
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: "CourseEnrollmentDb"));

            // Register Repositories
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();

            return services;
        }
    }
}

