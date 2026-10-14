using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SpendSense.Domain.Entities;
using SpendSense.Infrastructure.Identity;

namespace SpendSense.Infrastructure.Persistence.Configurations;


public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> b)
    {
        b.Property(t => t.TokenHash).HasMaxLength(200).IsRequired();
        b.HasIndex(t => t.TokenHash).IsUnique();
        b.Ignore(t => t.IsActive);

        b.HasOne<ApplicationUser>().WithMany().HasForeignKey(t => t.UserId).OnDelete(DeleteBehavior.Cascade);

    }
}