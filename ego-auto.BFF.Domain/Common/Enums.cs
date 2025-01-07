
namespace ego_auto.BFF.Domain.Common;

public enum VehicleStatus
{
    Unavailable,
    Available
}

public enum BookingStatus
{
    Pending,
    Ongoing,
    Completed,
    Cancelled
}

public enum PaymentStatus
{
    Paid,
    Pending,
    Failed
}

public enum UserRoles
{
    Admin,
    Renter,
    Support,
    Guest
}