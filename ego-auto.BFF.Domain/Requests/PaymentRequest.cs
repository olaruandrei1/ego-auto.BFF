using ego_auto.BFF.Domain.Common;

namespace ego_auto.BFF.Domain.Requests;

public class PaymentRequest
{
    public int? BookingId { get; set; }
    public decimal? Amount { get; set; }
    public PaymentStatus? Status { get; set; }
}
