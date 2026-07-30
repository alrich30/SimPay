namespace SimPay.Domain.Payments;

public sealed class Payment
{
    public Guid Id { get; private set; }
    public Guid SourceAccountId { get; private set; }
    public Guid DestinationAccountId { get; private set; }
    public decimal Amount { get; private set; }
    public string Currency { get; private set; }
    public string? Description { get; private set; }
    public PaymentStatus Status { get; private set; }
    public DateTime CreatedAtUtc { get; private set; }

    public Payment(
        Guid sourceAccountId,
        Guid destinationAccountId,
        decimal amount,
        string currency,
        string? description)
    {
        Id = Guid.NewGuid();
        SourceAccountId = sourceAccountId;
        DestinationAccountId = destinationAccountId;
        Amount = amount;
        Currency = currency;
        Description = description;
        Status = PaymentStatus.Pending;
        CreatedAtUtc = DateTime.UtcNow;
    }
}