using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineDeliveryProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.DataAccess.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.EstimatedDeliveryTimeMins).IsRequired(false);
            builder.Property(x => x.CustomerId).IsRequired();
            builder.Property(x => x.RestaurantId).IsRequired();

            builder.HasMany(x => x.OrderProducts).WithOne(x => x.Order).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
