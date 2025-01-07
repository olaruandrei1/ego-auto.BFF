using ego_auto.BFF.Domain.Common.Bindings;
using ego_auto.BFF.Domain.Utilities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ego_auto.BFF.Application.Utilities;

internal static class AuthHelper
{
    public static string GenerateJwtToken(TokenDependecies data, JwtConfiguration jwtConfiguration)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, data.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("userId", data.UserId.ToString()),
            new Claim("accountName", data.AccountName ?? "Guest"),
            new Claim(ClaimTypes.Role, data.Role ?? "Guest"),
        };

        SigningCredentials creds = new 
            (
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.Key!)),
                SecurityAlgorithms.HmacSha256
            );

        var token = new JwtSecurityToken(
            issuer: jwtConfiguration.Issuer,
            audience: jwtConfiguration.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(jwtConfiguration.TokenExpireInHours),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public static bool VerifyPassword(string inputPassword, string hashedPassword)
    => BCrypt.Net.BCrypt.Verify(inputPassword, hashedPassword);
}
