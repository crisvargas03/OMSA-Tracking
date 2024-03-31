using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OMSATrackingAPI.DAL.Models;

namespace OMSATrackingAPI.DAL.FluentConfiguration
{
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasQueryFilter(b => !b.IsDeleted);
            builder.Property(b => b.Id).IsRequired()
                .HasIdentityOptions(startValue: 1001);

            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(50);
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.CreationDate).IsRequired();

            builder.Property(b => b.Username).IsRequired().HasMaxLength(50);
            builder.Property(b => b.Password).IsRequired().HasMaxLength(50);

            builder.HasData(new AppUser
            {
                Id = 1001,
                Username = "Api",
                Password = "Api12345",
                CreatedBy = "Admin",
                CreationDate = DateTime.UtcNow,
                IsDeleted = false
            });
        }
    }
}
