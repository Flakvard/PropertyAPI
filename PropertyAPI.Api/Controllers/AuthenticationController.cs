using Microsoft.AspNetCore.Mvc;
using PropertyAPI.Contract.Authentication;
using PropertyAPI.Application.Services.Authentication;
using ErrorOr;
using PropertyAPI.Domain.Common.Errors;
namespace PropertyAPI.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{

    private readonly IAuthenticationService _authService;
    public AuthenticationController(IAuthenticationService authService){
        _authService = authService;
    }
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        ErrorOr<AuthenticationResult> authResult = _authService.Register(request.FirstName, request.LastName, request.Email, request.Password);

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );

    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request){

        var authResult = _authService.Login(
            request.Email,
            request.Password);
        
        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials){
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authResult.FirstError.Description);
        }

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token
        );
    }
}