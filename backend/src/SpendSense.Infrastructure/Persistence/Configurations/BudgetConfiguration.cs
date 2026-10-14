using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SpendSense.Domain.Entities;
using SpendSense.Infrastructure.Identity;

namespace SpendSense.Infrastructure.Persistence.Configurations;

public class BudgetConfiguration : IEntityTypeConfiguration<Budget>
{
    public void Configure(EntityTypeBuilder<Budget> b)
    {
        b.Property(x => x.LimitAmount).HasPrecision(18, 2);
        b.HasIndex(x => new { x.UserId, x.CategoryId, x.Month, x.Year }).IsUnique();

        b.HasOne<ApplicationUser>().WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
        b.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);


    }
}