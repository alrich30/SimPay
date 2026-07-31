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

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Payment>), StatusCodes.Status200OK)]
    public ActionResult<IReadOnlyCollection<Payment>> GetAll()
    {
        var payments = _paymentRepository.GetAll();

        return Ok(payments);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(Payment), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Payment> GetById(Guid id)
    {
        var payment = _paymentRepository.GetById(id);

        if (payment is null)
        {
            return NotFound();
        }

        return Ok(payment);
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

        return CreatedAtAction(
            nameof(GetById),
            new { id = payment.Id },
            payment);
        }


}