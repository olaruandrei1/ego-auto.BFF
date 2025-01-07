
using ego_auto.BFF.Domain.Entities;
using ego_auto.BFF.Domain.Requests;

namespace ego_auto.BFF.Application.Contracts;

public interface IUserRepository
{
    Task<User> GetUser(string email);
    Task<int> GetUserIdByEmail(string email);
    Task UpsertUser(SignUpRequest request);
}
