namespace SimPay.Application.Payments;

public sealed record CreatePaymentRequest(
    Guid SourceAccountId,
    Guid DestinationAccountId,
    decimal Amount,
    string Currency,
    string? Description);