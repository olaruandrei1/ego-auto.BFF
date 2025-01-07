using ego_auto.BFF.Domain.Common;
using ego_auto.BFF.Domain.Entities;
using ego_auto.BFF.Domain.Requests.Booking;

namespace ego_auto.BFF.Application.Contracts.Persistence;

public interface IBookingRepository
{
    Task<PaginatedResult<Booking>> GetBookingsAsync(GetBookingsRequest request);
    Task<Booking?> GetBookingByIdAsync(int id);
    Task UpsertBooking(BookingUpsertRequest booking);
    Task DeleteBookingAsync(int id);
}
