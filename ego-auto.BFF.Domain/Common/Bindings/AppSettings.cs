namespace ego_auto.BFF.Domain.Common.Bindings;

public class AppSettings
{
    public const string? Key = "AppSettings";
    public PaymentConfiguration? PaymentConfiguration { get; init; }
    public JwtConfiguration? JwtConfiguration { get; init; }
}

public partial class PaymentConfiguration
{
    public string? HttpClientName { get; init; }
    public string? BaseUrl { get; init; }
    public string? ExecutePayment { get; init; }
    public string? RefundPayment { get; init; }
    public string? CancelPayment { get; init; }
}

public partial class JwtConfiguration
{
    public string? Key { get; init; }
    public string? Issuer { get; init; }
    public string? Audience { get; init; }
    public double TokenExpireInHours { get; init; }
}
