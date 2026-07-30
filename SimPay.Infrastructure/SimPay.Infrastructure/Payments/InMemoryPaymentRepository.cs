using System.Collections.Concurrent;
using SimPay.Application.Payments;
using SimPay.Domain.Payments;

namespace SimPay.Infrastructure.Payments;

public sealed class InMemoryPaymentRepository : IPaymentRepository
{
    private readonly ConcurrentDictionary<Guid, Payment> _payments = new();

    public Payment Add(Payment payment)
    {
        var wasAdded = _payments.TryAdd(payment.Id, payment);

        if (!wasAdded)
        {
            throw new InvalidOperationException(
                $"A payment with identifier {payment.Id} already exists.");
        }

        return payment;
    }
}