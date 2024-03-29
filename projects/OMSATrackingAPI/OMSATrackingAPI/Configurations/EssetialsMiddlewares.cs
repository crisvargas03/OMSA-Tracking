using Microsoft.EntityFrameworkCore;
using OMSATrackingAPI.BLL.Mappers;
using OMSATrackingAPI.DAL.Data;

namespace OMSATrackingAPI.Configurations
{
    public static class EssetialsMiddlewares
    {
        private static void ConfigurateDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MainDbContext>(op =>
            {
                var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
                           ?? configuration.GetConnectionString("DEFAULT_DB");

                op.UseNpgsql(connectionString);
            });
        }

        private static void ConfigurateCors(this IServiceCollection services)
        {
            services.AddCors(p => p.AddPolicy("cors", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));
        }

        private static void ConfigurateServices(this IServiceCollection services)
        {
        }

        private static void ConfigurateRepositories(this IServiceCollection services)
        {
        }

        private static void ConfigurateAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CustomMapper));
        }

        public static void AddEssetialsMiddlewares(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigurateDbContext(configuration);
            services.ConfigurateRepositories();
            services.ConfigurateAutoMapper();
            services.ConfigurateServices();
            services.ConfigurateCors();
        }
    }
}
