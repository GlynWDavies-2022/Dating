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
            .HasMaxLength(50);
    }
}
