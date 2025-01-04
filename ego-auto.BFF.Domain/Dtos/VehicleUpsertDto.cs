namespace ego_auto.BFF.Domain.Dtos;

public class VehicleUpsertDto
{
    public int? VehicleId { get; set; } 
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public decimal PricePerDay { get; set; }
    public string Description { get; set; }
}
