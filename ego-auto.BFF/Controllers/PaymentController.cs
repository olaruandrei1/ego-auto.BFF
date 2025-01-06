using ego_auto.BFF.Application.Contracts;
using ego_auto.BFF.Domain.Requests;
using ego_auto.BFF.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace ego_auto.BFF.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentController(IPaymentService _service) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetPaymentsAsync([FromQuery] GetPaymentsRequest request)
    => Ok(await _service.GetPaymentsAsync(request));

    [HttpGet]
    [Route("id")]
    public async Task<IActionResult> GetPaymentByIdAsync(int id)
    => Ok(await _service.GetPaymentByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> MakePayment([FromBody] PaymentRequest request)
    => Ok(await _service.MakePayment(request));

    [HttpPut("update-payment-status")]
    public async Task<IActionResult> UpdatePaymentStatus([FromBody] UpdatePaymentStatusRequest request)
    => Ok(await _service.UpdatePaymentStatus(request));

    [HttpPatch]
    public async Task<IActionResult> RefundPayment(int id)
    => Ok(await _service.RefundPaymentAsync(id));
}
