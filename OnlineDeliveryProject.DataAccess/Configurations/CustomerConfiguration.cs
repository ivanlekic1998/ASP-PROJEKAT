using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineDeliveryProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.DataAccess.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.FullName).IsRequired();
            builder.Property(x => x.Address).IsRequired();

            builder.HasMany(x => x.Orders).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
