using SpendSense.Domain.Enums;
namespace SpendSense.Domain.Entities;

public class AiUsageLog
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public AiUsageType Type { get; set; }
    public int TokenUsed { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}