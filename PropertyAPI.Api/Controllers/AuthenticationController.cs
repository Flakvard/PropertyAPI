using Microsoft.AspNetCore.Mvc;
using PropertyAPI.Contract.Authentication;
using ErrorOr;
using PropertyAPI.Domain.Common.Errors;
using PropertyAPI.Application.Services.Authentication.Common;
using PropertyAPI.Application.Services.Authentication.Commands;
using PropertyAPI.Application.Services.Authentication.Queries;
namespace PropertyAPI.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{

    private readonly IAuthenticationCommandService _authCommandService;
    private readonly IAuthenticationQueryService _authQueryService;
    public AuthenticationController(IAuthenticationCommandService authenticationCommandService, IAuthenticationQueryService authenticationQueryService){
        _authCommandService = authenticationCommandService;
        _authQueryService = authenticationQueryService;
    }
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        ErrorOr<AuthenticationResult> authCommandResult = _authCommandService.Register(request.FirstName, request.LastName, request.Email, request.Password);

        return authCommandResult.Match(
            authCommandResult => Ok(MapAuthResult(authCommandResult)),
            errors => Problem(errors)
        );

    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request){

        var authQueryResult = _authQueryService.Login(
            request.Email,
            request.Password);
        
        if (authQueryResult.IsError && authQueryResult.FirstError == Errors.Authentication.InvalidCredentials){
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authQueryResult.FirstError.Description);
        }

        return authQueryResult.Match(
            authQueryResult => Ok(MapAuthResult(authQueryResult)),
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