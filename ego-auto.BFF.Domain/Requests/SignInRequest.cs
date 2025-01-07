using ego_auto.BFF.Domain.Common;

namespace ego_auto.BFF.Domain.Requests;

public record SignUpRequest(string? AccountName, string? Email, string? Password, string? Role);
