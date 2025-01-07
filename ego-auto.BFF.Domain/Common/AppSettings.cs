namespace ego_auto.BFF.Domain.Common;

public class AppSettings
{
    public PaymentConfiguration? PaymentConfiguration { get; init; }
}

public partial class PaymentConfiguration
{
    public string? HttpClientName { get; init; }
    public string? BaseUrl { get; init; }
    public string? ExecutePayment { get; init; }
    public string? RefundPayment { get; init; }
    public string? CancelPayment { get; init; }
}
