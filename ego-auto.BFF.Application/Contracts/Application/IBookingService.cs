using ego_auto.BFF.Domain.Common;
using ego_auto.BFF.Domain.Entities;
using ego_auto.BFF.Domain.Requests.Booking;
using ego_auto.BFF.Domain.Responses;

namespace ego_auto.BFF.Application.Contracts.Application;

public interface IBookingService
{
    Task<CustomResponse> DeleteBookingAsync(int id);
    Task<CustomResponse<Booking>> GetBookingByIdAsync(int id);
    Task<CustomResponse<PaginatedResult<Booking>>> GetBookingsAsync(GetBookingsRequest request);
    Task<CustomResponse> UpsertBooking(BookingUpsertRequest request);
}
