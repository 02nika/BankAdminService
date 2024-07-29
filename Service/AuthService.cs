using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Entities.Models;
using Entities.Models.Enums;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Service.Contracts;
using Shared.Config;

namespace Service;

public class AuthService : IAuthService
{
    private readonly ConfigSettings _configSettings;

    public AuthService(IOptions<ConfigSettings> jwtSettings)
    {
        _configSettings = jwtSettings.Value;
    }

    public string GenerateJwtToken(RoleType role)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Role, role.ToString()),
        };

        var jwtToken = new JwtSecurityToken(
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configSettings.JwtSecret)
                ),
                SecurityAlgorithms.HmacSha256Signature)
        );
        return new JwtSecurityTokenHandler().WriteToken(jwtToken);
    }
}