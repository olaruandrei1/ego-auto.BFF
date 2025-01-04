namespace ego_auto.BFF.Domain.Requests;

public class GetVehicleRequest
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? VehicleModelFilter { get; set; }
    public decimal? MinPricePerDayFilter { get; set; }
    public decimal? MaxPricePerDayFilter { get; set; }
    public string? StatusFilter { get; set; }
    public string? DescriptionFilter { get; set; }
}
