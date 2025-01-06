namespace ego_auto.BFF.Domain.Requests;

public class BookingUpsertRequest
{
    public int? VehicleId { get; set; }
    public int? BookingId { get; set; }
    public int? RenterId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Status { get; set; }
    public decimal? TotalPrice { get; set; }
}
