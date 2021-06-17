using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineDeliveryProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.RestaurantId).IsRequired();
            builder.Property(x => x.CategoryId).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Size).IsRequired();

            builder.HasMany(x => x.ProductOrders).WithOne(x => x.Product).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
