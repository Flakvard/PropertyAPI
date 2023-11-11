using PropertyAPI.Domain.Entities;

namespace PropertyAPI.Application.Commmon.Interfaces.Authentication;


// NOTE: Possibility to add an identity server like AAD (Azure Active Directory)
public interface IJwtTokenGenerator{
    string GenerateToken(User user);
}