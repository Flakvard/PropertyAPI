using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PropertyAPI.Application.Commmon.Interfaces.Authentication;
using PropertyAPI.Application.Commmon.Interfaces.Services;
using PropertyAPI.Domain.Entities;

namespace PropertyAPI.Infrastructure.Authentication;

// NOTE: Possibility to add an identity server like AAD (Azure Active Directory)
public class JwtTokenGenerator : IJwtTokenGenerator{

    private readonly IDateTimeProvider _dateTimeProvider;

    private readonly JwtTokenSettings _jwtTokenSettings;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider,IOptions<JwtTokenSettings> jwtOptions)
    {
        _jwtTokenSettings = jwtOptions.Value;
        _dateTimeProvider = dateTimeProvider;
    }

    public string GenerateToken(User user){
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtTokenSettings.Secret)),
                SecurityAlgorithms.HmacSha256);

        var claims = new[]{
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtTokenSettings.Issuer,
            audience: _jwtTokenSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtTokenSettings.ExperyMinutes),
            claims: claims,
            signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}