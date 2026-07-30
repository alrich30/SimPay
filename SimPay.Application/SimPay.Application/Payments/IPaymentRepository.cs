using SimPay.Domain.Payments;

namespace SimPay.Application.Payments;

public interface IPaymentRepository
{
    Payment Add(Payment payment);
}