namespace ego_auto.BFF.Domain.Requests.Authentication;

public record SignUpRequest(string? AccountName, string? Email, string? Password, string? Role);
