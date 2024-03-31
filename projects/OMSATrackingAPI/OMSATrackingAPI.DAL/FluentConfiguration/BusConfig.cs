using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OMSATrackingAPI.DAL.Models;

namespace OMSATrackingAPI.DAL.FluentConfiguration
{
    public class BusConfig : IEntityTypeConfiguration<Bus>
    {
        public void Configure(EntityTypeBuilder<Bus> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasQueryFilter(b => !b.IsDeleted);
            builder.Property(b => b.Id).IsRequired()
                .HasIdentityOptions(startValue: 1001);

            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(50);
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.CreationDate).IsRequired();

            builder.Property(b => b.Name).IsRequired().HasMaxLength(50);
            builder.Property(b => b.Latitude).IsRequired().HasMaxLength(50);
            builder.Property(b => b.Longitude).IsRequired().HasMaxLength(50);
            builder.Property(b => b.Plate).IsRequired().HasMaxLength(20);
            builder.Property(b => b.EstimatedArrivalHour).IsRequired();
            builder.Property(b => b.PassengerLimit).IsRequired();
            builder.Property(b => b.RouteId).IsRequired();

            builder.HasOne(b => b.Route)
                .WithMany(r => r.Buses)
                .HasForeignKey(b => b.RouteId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(b => b.Driver)
                .WithOne(d => d.Bus)
                .HasForeignKey<Driver>(d => d.BusId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(b => b.FavoriteRoute)
                .WithOne(f => f.Bus)
                .HasForeignKey<FavoriteRoute>(f => f.IdBus)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new Bus
            {
                Id = 1001,
                Name = "Bus 1",
                Latitude = "18.486057",
                Longitude = "-69.931212",
                Plate = "A123456",
                EstimatedArrivalHour = new TimeOnly(8, 0).ToShortTimeString(), // 8:00 AM
                PassengerLimit = 30,
                RouteId = 1001,
                CreatedBy = "Admin",
                CreationDate = DateTime.UtcNow,
                IsDeleted = false,

            },
            new Bus
            {
                Id = 1002,
                Name = "Bus 2",
                Latitude = "18.486057",
                Longitude = "-69.931212",
                Plate = "B123456",
                EstimatedArrivalHour = new TimeOnly(8, 0).ToShortTimeString(), // 8:00 AM
                PassengerLimit = 30,
                RouteId = 1002,
                CreatedBy = "Admin",
                CreationDate = DateTime.UtcNow,
                IsDeleted = false
            });
        }
    }
}
