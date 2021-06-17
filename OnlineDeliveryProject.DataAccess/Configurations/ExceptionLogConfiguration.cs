﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineDeliveryProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineDeliveryProject.DataAccess.Configurations
{
    public class ExceptionLogConfiguration : IEntityTypeConfiguration<ExceptionLog>
    {
        public void Configure(EntityTypeBuilder<ExceptionLog> builder)
        {

            builder.Property(x => x.Response).IsRequired();

            builder.Property(x => x.StatusCode).IsRequired().HasColumnType("bigint");

            builder.Property(x => x.Exception).IsRequired();
        }
    }
}
