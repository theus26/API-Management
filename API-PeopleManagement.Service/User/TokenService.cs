using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API_PeopleManagement.Domain.Enum;
using API_PeopleManagement.Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace API_PeopleManagement.Service.User;

public class TokenService : ITokenService
{
    public string GenerateToken(Guid userId, Roles role)
    {
        var handler = new JwtSecurityTokenHandler();
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("super duper ultra top secret key of all time!")
        );

        var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256Signature
        );

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = GenerateClaims(userId, role),
            Expires = DateTime.UtcNow.AddMinutes(15),
            SigningCredentials = credentials
        };

        var token = handler.CreateToken(tokenDescriptor);

        return handler.WriteToken(token);
    }
    
    private static ClaimsIdentity GenerateClaims(Guid userId, Roles roles)
    {
        var claims = new ClaimsIdentity();
        claims.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()));
        claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, userId.ToString()));
        claims.AddClaim(new Claim(ClaimTypes.Role, roles.ToString()));
       
        return claims;
    }
}
