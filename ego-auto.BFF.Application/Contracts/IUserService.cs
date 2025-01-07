
using ego_auto.BFF.Domain.Requests;
using ego_auto.BFF.Domain.Responses;

namespace ego_auto.BFF.Application.Contracts;

public interface IUserService
{
    Task<AuthenticationResponse> LogIn(LogInRequest request);
    Task<AuthenticationResponse> SignUp(SignUpRequest request);
}
