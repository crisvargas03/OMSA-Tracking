using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OMSATrackingAPI.DAL.Models;

namespace OMSATrackingAPI.DAL.FluentConfiguration
{
    public class DriverConfig : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasQueryFilter(b => !b.IsDeleted);
            builder.Property(b => b.Id).IsRequired()
                .HasIdentityOptions(startValue: 1001);

            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(50);
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.CreationDate).IsRequired();

            builder.Property(b => b.Name).IsRequired().HasMaxLength(50);
            builder.Property(b => b.LastName).IsRequired().HasMaxLength(50);
            builder.Property(b => b.IndentificationDocument).IsRequired().HasMaxLength(20);
            builder.Property(b => b.BusId).IsRequired();

            builder.HasOne(b => b.Bus)
                .WithOne(r => r.Driver)
                .HasForeignKey<Driver>(b => b.BusId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new Driver
            {
                Id = 1001,
                Name = "Driver 1",
                LastName = "Driver 1",
                IndentificationDocument = "123456789",
                BusId = 1001,
                CreatedBy = "Admin",
                CreationDate = DateTime.Now,
                IsDeleted = false
            },
            new Driver
            {
                Id = 1002,
                Name = "Driver 2",
                LastName = "Driver 2",
                IndentificationDocument = "987654321",
                BusId = 1002,
                CreatedBy = "Admin",
                CreationDate = DateTime.Now,
                IsDeleted = false
            });
        }
    }
}
