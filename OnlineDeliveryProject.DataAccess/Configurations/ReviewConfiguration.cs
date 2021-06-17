using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineDeliveryProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.DataAccess.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.Property(x => x.CustomerId).IsRequired();
            builder.Property(x => x.RestaurantId).IsRequired();
            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(200);
            builder.Property(x => x.Rating).IsRequired(false);
        }
    }
}
