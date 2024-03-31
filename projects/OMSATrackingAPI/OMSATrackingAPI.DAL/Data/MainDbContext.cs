using Microsoft.EntityFrameworkCore;
using OMSATrackingAPI.DAL.Models;
using System.Reflection;

namespace OMSATrackingAPI.DAL.Data
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) 
            : base(options){ }

        public DbSet<AppUser> Users => Set<AppUser>();
        public DbSet<Bus> Buss => Set<Bus>();
        public DbSet<Driver> Drivers => Set<Driver>();
        public DbSet<FavoriteRoute> FavoriteRoutes => Set<FavoriteRoute>();
        public DbSet<Route> Route => Set<Route>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var assembly = Assembly.GetExecutingAssembly();
            var entitiesConfigs = assembly.GetTypes()
                .Where(t => t.Namespace == "OMSATrackingAPI.DAL.FluentConfiguration"
                && t.GetInterfaces().Any(i => i.IsGenericType
                    && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                ).ToList();

            modelBuilder.UseIdentityByDefaultColumns();

            foreach (var entityConfig in entitiesConfigs)
            {
                dynamic configurationInstance = Activator.CreateInstance(entityConfig)!;
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }
    }
}
