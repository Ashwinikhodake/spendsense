using SpendSense.Domain.Enums;

namespace SpendSense.Domain.Entities;

public class Expense
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "INR";
    public string? Merchant { get; set; }
    public string? Note { get; set; }
    public DateOnly ExpenseDate { get; set; }
    public ExpenseSource Source { get; set; } = ExpenseSource.Manual;
    public string? ReceiptUrl { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public Category Category { get; set; } = null!;
}