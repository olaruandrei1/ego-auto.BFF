using ego_auto.BFF.Application.Contracts;
using ego_auto.BFF.Domain.Entities;
using ego_auto.BFF.Domain.Requests;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data;

namespace ego_auto.BFF.Persistence.Repositories;

public sealed class UserRepository(AppDbContext _context) : IUserRepository
{
    public async Task<User> GetUser(string email) => await _context.Users.FirstOrDefaultAsync(ef => ef.Email == email);

    public async Task<int> GetUserIdByEmail(string email)
    => await _context.Users
           .Where(u => u.Email == email)
           .Select(u => u.Id)
           .FirstOrDefaultAsync();

    public async Task UpsertUser(SignUpRequest request)
    {
        NpgsqlParameter accountNameParam = new("p_account_name", request.AccountName ?? (object)DBNull.Value)
        {
            Direction = ParameterDirection.Input
        }; 
        NpgsqlParameter emailParam = new("p_email", request.Email ?? (object)DBNull.Value)
        {
            Direction = ParameterDirection.Input
        };
        NpgsqlParameter passwordParam = new("p_password", request.Password ?? (object)DBNull.Value)
        {
            Direction = ParameterDirection.Input
        };
        NpgsqlParameter roleParam = new("p_role", request.Role ?? (object)DBNull.Value)
        {
            Direction = ParameterDirection.Input
        };
        NpgsqlParameter userIdParam = new("user_id", NpgsqlTypes.NpgsqlDbType.Integer)
        {
            Direction = ParameterDirection.Output
        };

        await _context.Database.ExecuteSqlRawAsync(
            "CALL public.upsert_user(@p_account_name, @p_email, @p_password, @p_role);",
            accountNameParam,
            emailParam,
            passwordParam,
            roleParam
        );
    }
}
