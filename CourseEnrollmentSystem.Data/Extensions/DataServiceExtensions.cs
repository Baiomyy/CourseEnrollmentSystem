using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CourseEnrollmentSystem.Data.Contexts;

namespace CourseEnrollmentSystem.Data.Extensions
{
    public static class DataServiceExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            // Configure Entity Framework Core with In-Memory Database
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: "CourseEnrollmentDb"));

            return services;
        }
    }
}

