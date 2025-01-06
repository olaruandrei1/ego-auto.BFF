using ego_auto.BFF.Domain.Common;
using ego_auto.BFF.Domain.Entities;

namespace ego_auto.BFF.Domain.Dtos;

public class BookingEventsDto
{
    public BookingStatus? BookingStatus { get; set; } = null;
    public VehicleStatus? VehicleStatus { get; set; } = null;
    public Booking? Booking { get; set; } = null;
    public Vehicle? Vehicle { get; set; } = null;
}
