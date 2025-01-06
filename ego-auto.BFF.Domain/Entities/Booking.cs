using System.ComponentModel.DataAnnotations.Schema;

namespace ego_auto.BFF.Domain.Entities;

public class Booking
{
    [Column("id")]
    public int Id { get; set; }
    [Column("vehicle_id")]
    public int VehicleId { get; set; }
    [Column("renter_id")]
    public int RenterId { get; set; }
    [Column("start_date")]
    public DateTime StartDate { get; set; }
    [Column("end_date")]
    public DateTime EndDate { get; set; }
    [Column("total_price")]
    public decimal TotalPrice { get; set; }
    [Column("status")]
    public string Status { get; set; }
}
