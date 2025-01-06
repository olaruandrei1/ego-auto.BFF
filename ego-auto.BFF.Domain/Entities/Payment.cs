using System.ComponentModel.DataAnnotations.Schema;

namespace ego_auto.BFF.Domain.Entities;

public class Payment
{
    [Column("id")]
    public int Id { get; set; }
    [Column("booking_id")]
    public int BookingId { get; set; }
    [Column("amount")]
    public decimal Amount { get; set; }
    [Column("payment_date")]
    public DateTime PaymentDate { get; set; }
    [Column("status")]
    public string Status { get; set; }
}
