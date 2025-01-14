namespace ego_auto.BFF.Domain.Common.Bindings;

public class CorsSettings
{
    public const string? Key = "CorsSettings";

    public Dictionary<string, string> Policies { get; init; } = new();
}
