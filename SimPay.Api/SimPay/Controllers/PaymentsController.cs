using Microsoft.AspNetCore.Mvc;
using SimPay.Application.Payments;
using SimPay.Domain.Payments;

namespace SimPay.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class PaymentsController : ControllerBase
{
    private readonly IPaymentRepository _paymentRepository;

    public PaymentsController(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    [HttpPost]
    [ProducesResponseType(typeof(Payment), StatusCodes.Status201Created)]
    public ActionResult<Payment> Create(CreatePaymentRequest request)
    {
        var payment = new Payment(
            request.SourceAccountId,
            request.DestinationAccountId,
            request.Amount,
            request.Currency,
            request.Description);

        _paymentRepository.Add(payment);

        return Created($"/api/payments/{payment.Id}", payment);
    }


}