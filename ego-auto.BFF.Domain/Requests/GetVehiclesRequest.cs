namespace ego_auto.BFF.Domain.Requests;

public class GetVehiclesRequest
{
    public string? MakeFilter { get; set; }
    public string? ModelFilter { get; set; }
    public decimal? PricePerDayFilter { get; set; }
    public string? StatusFilter { get; set; }
    public string? DescriptionFilter { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
