using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineDeliveryProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.DataAccess.Configurations
{
    class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.PostCode).IsRequired();
            builder.HasIndex(x => x.PostCode).IsUnique();

            builder.HasMany(x => x.Customers).WithOne(x => x.City).HasForeignKey(x => x.CityId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Restaurants).WithOne(x => x.City).HasForeignKey(x => x.CityId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
