using Microsoft.EntityFrameworkCore;
using OMSATrackingAPI.BLL.Interfaces;
using OMSATrackingAPI.BLL.Mappers;
using OMSATrackingAPI.BLL.Services;
using OMSATrackingAPI.DAL.Data;
using OMSATrackingAPI.DAL.Repository;
using OMSATrackingAPI.DAL.Repository.IRepository;

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
            services.AddScoped<IBusService, BusService>();
            services.AddScoped<IRoutesService, RouteService>();
        }

        private static void ConfigurateRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBusRepository, BusRepository>();
            services.AddScoped<IRouteRepository, RouteRepository>();
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
