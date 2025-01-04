namespace ego_auto.BFF.Domain.Entities;

public class VehicleModel
{
    public int Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public decimal PricePerDay { get; set; }
    public string Status { get; set; }
    public string? Description { get; set; }
}
