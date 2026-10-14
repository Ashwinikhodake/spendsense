using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SpendSense.Domain.Entities;
using SpendSense.Infrastructure.Identity;

namespace SpendSense.Infrastructure.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> b)
    {
        b.Property(c => c.Name).HasMaxLength(50).IsRequired();
        b.Property(c => c.Icon).HasMaxLength(50);
        b.Property(c => c.Color).HasMaxLength(50);

        b.HasOne<ApplicationUser>().WithMany().HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.Cascade);
        b.HasData(
       Seed("11111111-0000-0000-0000-000000000001", "Food & Dining", "restaurant", "#FF7043"),
       Seed("11111111-0000-0000-0000-000000000002", "Transport", "directions_car", "#42A5F5"),
       Seed("11111111-0000-0000-0000-000000000003", "Shopping", "shopping_bag", "#AB47BC"),
       Seed("11111111-0000-0000-0000-000000000004", "Bills & Utilities", "receipt_long", "#FFA726"),
       Seed("11111111-0000-0000-0000-000000000005", "Entertainment", "movie", "#EC407A"),
       Seed("11111111-0000-0000-0000-000000000006", "Health", "favorite", "#66BB6A"),
       Seed("11111111-0000-0000-0000-000000000007", "Other", "category", "#9E9E9E"));
    }
    private static Category Seed(string id, string name, string icon, string color) => new() { Id = Guid.Parse(id), UserId = null, Name = name, Icon = icon, Color = color };


}