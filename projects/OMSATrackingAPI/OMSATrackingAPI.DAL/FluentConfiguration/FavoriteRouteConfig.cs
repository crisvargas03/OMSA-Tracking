using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OMSATrackingAPI.DAL.Models;

namespace OMSATrackingAPI.DAL.FluentConfiguration
{
    public class FavoriteRouteConfig : IEntityTypeConfiguration<FavoriteRoute>
    {
        public void Configure(EntityTypeBuilder<FavoriteRoute> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasQueryFilter(b => !b.IsDeleted);
            builder.Property(b => b.Id).IsRequired();

            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(50);
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.CreationDate).IsRequired();

            builder.Property(b => b.UserIdentificationCode).IsRequired();
            builder.Property(b => b.IdBus).IsRequired();

            builder.HasOne(b => b.Bus)
                .WithOne(r => r.FavoriteRoute)
                .HasForeignKey<FavoriteRoute>(b => b.IdBus)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
