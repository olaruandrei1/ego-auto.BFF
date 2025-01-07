using ego_auto.BFF.Domain.Entities;
using ego_auto.BFF.Domain.Requests.Booking;

namespace ego_auto.BFF.Application.Utilities;

internal static class Extensions
{
    internal static BookingUpsertRequest MapBookingToUpsert(this Booking data)
    => new()
    {
        VehicleId = data.VehicleId,
        RenterId = data.RenterId,
        BookingId = data.Id,
        StartDate = data.StartDate,
        EndDate = data.EndDate,
        Status = data.Status,
        TotalPrice = data.TotalPrice,
    };
}
