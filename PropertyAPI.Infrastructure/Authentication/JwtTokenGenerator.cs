using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PropertyAPI.Application.Commmon.Interfaces.Authentication;
using PropertyAPI.Application.Commmon.Interfaces.Services;

namespace PropertyAPI.Infrastructure.Authentication;

// NOTE: Possibility to add an identity server like AAD (Azure Active Directory)
public class JwtTokenGenerator : IJwtTokenGenerator{

    private readonly IDateTimeProvider _dateTimeProvider;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public string GenerateToken(Guid userid, string FirstName, string LastName){
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("super-secret-keysuper-secret-key")),
                SecurityAlgorithms.HmacSha256);

        var claims = new[]{
            new Claim(JwtRegisteredClaimNames.Sub, userid.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var securityToken = new JwtSecurityToken(
            issuer: "PropertyApi",
            expires: _dateTimeProvider.UtcNow.AddMinutes(60),
            claims: claims,
            signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}