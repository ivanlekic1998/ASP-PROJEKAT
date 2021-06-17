using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineDeliveryProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.DataAccess.Configurations
{
    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Phone).IsRequired();

            builder.HasMany(x => x.Reviews).WithOne(x => x.Restaurant).HasForeignKey(x => x.RestaurantId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Products).WithOne(x => x.Restaurant).HasForeignKey(x => x.RestaurantId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Orders).WithOne(x => x.Restaurant).HasForeignKey(x => x.RestaurantId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
