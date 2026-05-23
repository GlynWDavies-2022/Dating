using Dating.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dating.Infrastructure.Configuration;

public class BaseEntityConfiguration : IEntityTypeConfiguration<BaseEntity>
{
    public void Configure(EntityTypeBuilder<BaseEntity> builder)
    {
        builder
            .Property(b => b.CreatedBy)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(b => b.UpdatedBy)
            .IsRequired()
            .HasMaxLength(50);
    }
}
