using System.IdentityModel.Tokens.Jwt;

namespace PropertyAPI.Infrastructure.Authentication;

public class JwtTokenSettings{
    public const string SectionName = "JwtTokenSettings";
    public required string Secret {get; init;}
    public required double ExperyMinutes {get; init;}
    public required string Issuer {get; init;}
    public required string Audience {get; init;}
}