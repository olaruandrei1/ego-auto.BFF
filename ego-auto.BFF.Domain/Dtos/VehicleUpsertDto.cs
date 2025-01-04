namespace ego_auto.BFF.Domain.Dtos;

public class VehicleUpsertDto
{
    public int? VehicleId { get; set; } = null;
    public string? Make { get; set; } = null;
    public string? Model { get; set; } = null;
    public int? Year { get; set; } = null;
    public decimal? PricePerDay { get; set; } = null;
    public string? Description { get; set; } = null;
}
