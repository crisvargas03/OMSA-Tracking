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
            builder.Property(b => b.StopId).IsRequired();

            builder.HasOne(b => b.Route)
                .WithMany(r => r.Buses)
                .HasForeignKey(b => b.RouteId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(b => b.Stop)
             .WithMany(r => r.Buses)
             .HasForeignKey(b => b.StopId)
             .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(b => b.Driver)
                .WithOne(d => d.Bus)
                .HasForeignKey<Driver>(d => d.BusId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(b => b.FavoriteRoute)
                .WithOne(f => f.Bus)
                .HasForeignKey<FavoriteRoute>(f => f.IdBus)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
