using ego_auto.BFF.Application.Contracts;

namespace ego_auto.BFF.Application.Implementations;

public class UserService(IUserRepository _userRepository) : IUserService
{
}
