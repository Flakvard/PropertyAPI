using System.IdentityModel.Tokens.Jwt;

namespace PropertyAPI.Infrastructure.Authentication;

public class JwtTokenSettings{
    public const string SectionName = "JwtTokenSettings";
    public string Secret {get; init;} = null!;
    public double ExperyMinutes {get; init;} 
    public string Issuer {get; init;} = null!;
    public string Audience {get; init;} = null!;
}