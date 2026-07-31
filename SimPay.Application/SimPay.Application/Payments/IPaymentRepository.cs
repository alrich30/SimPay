using SimPay.Domain.Payments;

namespace SimPay.Application.Payments;

public interface IPaymentRepository
{
    Payment Add(Payment payment);
    IReadOnlyCollection<Payment> GetAll();
    Payment? GetById(Guid id);
}