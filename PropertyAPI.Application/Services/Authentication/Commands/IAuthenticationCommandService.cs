using ErrorOr;
using PropertyAPI.Application.Services.Authentication.Common;

namespace PropertyAPI.Application.Services.Authentication.Commands;

public interface IAuthenticationCommandService
{
    ErrorOr<AuthenticationResult> Register(string FirstName, string LastName, string Email, string Password);
}