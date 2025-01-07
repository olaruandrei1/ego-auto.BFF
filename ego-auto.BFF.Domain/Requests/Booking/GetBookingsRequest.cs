namespace ego_auto.BFF.Domain.Requests.Booking;

public class GetBookingsRequest
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public int? RenterId { get; set; }
    public string? UserGroupType { get; set; }
}
