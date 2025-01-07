using ego_auto.BFF.Application.Contracts.Application;
using ego_auto.BFF.Domain.Requests.Payment;
using ego_auto.BFF.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ego_auto.BFF.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentController(IPaymentService _service) : BaseController
{
    [Authorize(Roles = "Admin, Renter")]
    [HttpGet]
    public async Task<IActionResult> GetPaymentsAsync([FromQuery] GetPaymentsRequest request)
    => Ok(await _service.GetPaymentsAsync(request));

    [Authorize(Roles = "Admin, Renter")]
    [HttpGet]
    [Route("id")]
    public async Task<IActionResult> GetPaymentByIdAsync(int id)
    => Ok(await _service.GetPaymentByIdAsync(id));

    [Authorize(Roles = "Admin, Renter")]
    [HttpPost]
    public async Task<IActionResult> MakePayment([FromBody] PaymentRequest request)
    => Ok(await _service.MakePayment(request, 0));

    [Authorize(Roles = "Admin")]
    [HttpPut("update-payment-status")]
    public async Task<IActionResult> UpdatePaymentStatus([FromBody] UpdatePaymentStatusRequest request)
    => Ok(await _service.UpdatePaymentStatus(request));

    [Authorize(Roles = "Admin")]
    [HttpPatch]
    public async Task<IActionResult> RefundPayment(int id)
    => Ok(await _service.RefundPaymentAsync(id));
}
