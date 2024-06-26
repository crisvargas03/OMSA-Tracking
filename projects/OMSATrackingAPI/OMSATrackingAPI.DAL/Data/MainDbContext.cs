﻿using Microsoft.EntityFrameworkCore;
using OMSATrackingAPI.DAL.Models;
using System.Reflection;

namespace OMSATrackingAPI.DAL.Data
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) 
            : base(options){ }

        public DbSet<AppUser> AppUsers => Set<AppUser>();
        public DbSet<Bus> Buses => Set<Bus>();
        public DbSet<Driver> Drivers => Set<Driver>();
        public DbSet<FavoriteRoute> FavoriteRoutes => Set<FavoriteRoute>();
        public DbSet<Route> Route => Set<Route>();
        public DbSet<BusStop> BusStop => Set<BusStop>();
        public DbSet<FavoriteBusStop> FavoriteBusStop => Set<FavoriteBusStop>();

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
