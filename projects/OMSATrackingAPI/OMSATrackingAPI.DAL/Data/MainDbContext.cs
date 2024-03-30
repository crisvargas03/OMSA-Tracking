using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace OMSATrackingAPI.DAL.Data
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) 
            : base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseSerialColumns();
            var assembly = Assembly.GetExecutingAssembly();
            var entitiesConfigs = assembly.GetTypes()
                .Where(t => t.Namespace == "OMSATrackingAPI.DAL.FluentConfiguration"
                && t.GetInterfaces().Any(i => i.IsGenericType
                    && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                ).ToList();

            foreach (var entityConfig in entitiesConfigs)
            {
                dynamic configurationInstance = Activator.CreateInstance(entityConfig)!;
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }
    }
}
