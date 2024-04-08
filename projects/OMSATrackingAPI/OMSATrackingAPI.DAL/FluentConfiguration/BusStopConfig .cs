using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OMSATrackingAPI.DAL.Models;

namespace OMSATrackingAPI.DAL.FluentConfiguration
{
    public class BusStopConfig : IEntityTypeConfiguration<BusStop>
    {
        public void Configure(EntityTypeBuilder<BusStop> builder)
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
            builder.Property(b => b.Position).IsRequired(); 

            builder.HasOne(b => b.Route)
                .WithMany()
                .HasForeignKey(b => b.RouteId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
