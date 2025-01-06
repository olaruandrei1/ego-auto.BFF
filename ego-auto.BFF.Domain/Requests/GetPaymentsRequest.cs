using ego_auto.BFF.Domain.Common;

namespace ego_auto.BFF.Domain.Requests;

public class GetPaymentsRequest
{
    public PaymentStatus? Status { get; set; }
    public decimal? MinAmount { get; set; }
    public decimal? MaxAmount { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int UserId { get; set; }
    public string? AutorizeGroup { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
