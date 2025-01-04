using System.ComponentModel.DataAnnotations.Schema;

namespace ego_auto.BFF.Domain.Entities;

public class Vehicle
{
    [Column("id")]
    public int Id { get; set; }

    [Column("make")]
    public string Make { get; set; }

    [Column("model")]
    public string Model { get; set; }

    [Column("year")]
    public int Year { get; set; }

    [Column("price_per_day")]
    public decimal PricePerDay { get; set; }

    [Column("status")]
    public string Status { get; set; }

    [Column("description")]
    public string? Description { get; set; }
}