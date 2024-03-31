using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OMSATrackingAPI.DAL.Models;

namespace OMSATrackingAPI.DAL.FluentConfiguration
{
    public class RouteConfing : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasQueryFilter(b => !b.IsDeleted);
            builder.Property(b => b.Id).IsRequired()
                .HasIdentityOptions(startValue: 1001);

            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(50);
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.CreationDate).IsRequired();

            builder.Property(b => b.Code).IsRequired().HasMaxLength(50);
            builder.Property(b => b.Address).IsRequired().HasMaxLength(50);
            builder.Property(b => b.Name).IsRequired().HasMaxLength(50);
            builder.Property(b => b.Origin).IsRequired().HasMaxLength(50);
            builder.Property(b => b.Destination).IsRequired().HasMaxLength(50);

            builder.HasMany(b => b.Buses)
                .WithOne(r => r.Route)
                .HasForeignKey(b => b.RouteId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
