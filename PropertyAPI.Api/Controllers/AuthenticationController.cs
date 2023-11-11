using Microsoft.AspNetCore.Mvc;
using PropertyAPI.Contract.Authentication;
using PropertyAPI.Application.Services.Authentication;
using ErrorOr;
namespace PropertyAPI.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
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
            _ => Problem(statusCode: StatusCodes.Status409Conflict, title: "User already exists")
        );

    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request){
        ErrorOr<AuthenticationResult> authResult = _authService.Login(request.Email, request.Password);

        return authResult.MatchFirst(
            authResult => Ok(MapAuthResult(authResult)),
            firstError => Problem(statusCode: StatusCodes.Status409Conflict, title: firstError.Description)
        );
        // var authResult = _authService.Login(request.Email, request.Password);
        // var response = new AuthenticationResponse(
        //     authResult.User.Id,
        //     authResult.User.FirstName,
        //     authResult.User.LastName,
        //     authResult.User.Email,
        //     authResult.Token
        // );
        // return Ok(response);
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