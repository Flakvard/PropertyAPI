using ErrorOr;
using PropertyAPI.Application.Services.Authentication.Common;

namespace PropertyAPI.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResult> Login(string Email, string Password);
}