using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SpendSense.Domain.Entities;
using SpendSense.Infrastructure.Identity;

namespace SpendSense.Infrastructure.Persistence.Configurations;

public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> b)
    {
        b.Property(e => e.Amount).HasPrecision(18, 2);
        b.Property(e => e.Currency).HasMaxLength(3).IsRequired();
        b.Property(e => e.Merchant).HasMaxLength(200);
        b.Property(e => e.Note).HasMaxLength(500);
        b.Property(e => e.ReceiptUrl).HasMaxLength(500);
        b.Property(e => e.ReceiptUrl).HasConversion<string>().HasMaxLength(20);

        b.HasIndex(e => new { e.UserId, e.ExpenseDate });

        b.HasOne<ApplicationUser>().WithMany().HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Cascade);
        b.HasOne(e => e.Category).WithMany(c => c.Expenses).HasForeignKey(e => e.CategoryId).OnDelete(DeleteBehavior.Restrict);

    }
}
