﻿using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Configurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(s => s.Image).IsRequired();
            builder.Property(s => s.Title).IsRequired().HasMaxLength(50);
            builder.Property(s => s.Description).IsRequired();
            builder.Property(s => s.SoftDeleted).HasDefaultValue(false);
            builder.Property(s => s.CreateDate).HasDefaultValue(DateTime.Now);
            builder.Property(s => s.UpdateDate).HasDefaultValue(DateTime.Now);
        }
    }
}