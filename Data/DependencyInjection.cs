using AQRS_import_and_export_archives.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AQRS_import_and_export_archives.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ContextDbApplication>(options =>
                options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 23))));

            services.AddScoped<IMediaRepository, MediaRepository>();

            return services;
        }
    }
}
