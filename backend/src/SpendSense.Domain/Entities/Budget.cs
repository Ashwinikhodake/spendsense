namespace SpendSense.Domain.Entities;

public class Budget
{

    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public Guid? CategoryId { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public decimal LimitAmount { get; set; }
    public Category? Category { get; set; }
}