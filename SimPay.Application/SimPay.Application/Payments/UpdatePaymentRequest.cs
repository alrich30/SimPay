namespace SimPay.Application.Payments;

public sealed record UpdatePaymentRequest(
    decimal Amount,
    string Currency,
    string? Description);