
using ego_auto.BFF.Application.Contracts;
using ego_auto.BFF.Domain.Requests;
using ego_auto.BFF.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace ego_auto.BFF.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingController(IBookingService _service) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBookingsAsync([FromQuery] GetBookingsRequest request)
    => Ok(await _service.GetBookingsAsync(request));

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetBookingAsync(int id)
    => Ok(await _service.GetBookingByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> UpsertBookingAsync(BookingUpsertRequest request)
    => Ok(await _service.UpsertBooking(request));

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteBookingAsync(int id)
    => Ok(await _service.DeleteBookingAsync(id));
}
