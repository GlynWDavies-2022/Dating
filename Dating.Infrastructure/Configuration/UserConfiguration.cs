using Dating.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dating.Infrastructure.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .Property(u => u.DisplayName)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(75);

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
