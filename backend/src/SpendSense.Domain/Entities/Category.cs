using SpendSense.Domain.Enums;

namespace SpendSense.Domain.Entities;

public class Category
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid? UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Icon { get; set; } = "category";
    public string Color { get; set; } = "#9E9E9E";

    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}