using SimPay.Domain.Payments;

namespace Simpay.Tests.Payments;

public sealed class PaymentTests
{
    [Fact]
    public void Create_WithValidData_ShouldCreatePendingPayment()
    {
        var sourceAccountId = Guid.NewGuid();
        var destinationAccountId = Guid.NewGuid();
        var beforeCreation = DateTime.UtcNow;

        var payment = new Payment(
            sourceAccountId,
            destinationAccountId,
            1500m,
            "DOP",
            "Pago simulado de prueba");

        var afterCreation = DateTime.UtcNow;

        Assert.NotEqual(Guid.Empty, payment.Id);
        Assert.Equal(sourceAccountId, payment.SourceAccountId);
        Assert.Equal(destinationAccountId, payment.DestinationAccountId);
        Assert.Equal(1500m, payment.Amount);
        Assert.Equal("DOP", payment.Currency);
        Assert.Equal("Pago simulado de prueba", payment.Description);
        Assert.Equal(PaymentStatus.Pending, payment.Status);
        Assert.InRange(payment.CreatedAtUtc, beforeCreation, afterCreation);
    }
}