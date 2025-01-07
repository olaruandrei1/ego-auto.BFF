using ego_auto.BFF.Application.Contracts.Application;
using ego_auto.BFF.Domain.Requests.Booking;
using ego_auto.BFF.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ego_auto.BFF.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingController(IBookingService _service) : BaseController
{
    [Authorize(Roles = "Admin, Renter")]
    [HttpGet]
    public async Task<IActionResult> GetBookingsAsync([FromQuery] GetBookingsRequest request)
    => Ok(await _service.GetBookingsAsync(request));

    [Authorize(Roles = "Admin, Renter")]
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetBookingAsync(int id)
    => Ok(await _service.GetBookingByIdAsync(id));

    [Authorize(Roles = "Admin, Renter")]
    [HttpPost]
    public async Task<IActionResult> UpsertBookingAsync(BookingUpsertRequest request)
    => Ok(await _service.UpsertBooking(request));

    [Authorize(Roles = "Admin, Renter")]
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteBookingAsync(int id)
    => Ok(await _service.DeleteBookingAsync(id));
}
