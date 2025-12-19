using Microsoft.Extensions.DependencyInjection;
using CourseEnrollmentSystem.Business.Interfaces;
using CourseEnrollmentSystem.Business.Services;

namespace CourseEnrollmentSystem.Business.Extensions
{
    public static class BusinessServiceExtensions
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            // Register Business Services
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IEnrollmentService, EnrollmentService>();

            return services;
        }
    }
}

