using LearningCentre.Infra.Domain;
using Microsoft.EntityFrameworkCore;

namespace LEARNING_CENTRE_PROJECT.Configuration
{
    public static class SqlServerConfiguration
    {
        public static void AddSqlServerr(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:DefaultConnection"];

            services.AddDbContext<LearningCentreContext>(options =>
            {
                options.EnableSensitiveDataLogging();
                options.UseSqlServer(connectionString, x =>
                {
                    x.MigrationsAssembly("LearningCentre.Infra.Domain");
                    x.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
                });
            }, ServiceLifetime.Singleton);
        }
    }
}
