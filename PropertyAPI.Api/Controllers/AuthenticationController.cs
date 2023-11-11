using Microsoft.AspNetCore.Mvc;
using PropertyAPI.Contract.Authentication;
using PropertyAPI.Application.Services.Authentication;
using PropertyAPI.Api.Filters;
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
    public IActionResult Register(RegisterRequest request){
        var authResult = _authService.Register(request.FirstName,request.LastName, request.Email, request.Password);

        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token
        );
        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request){
        var authResult = _authService.Login(request.Email, request.Password);
        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token
        );
        return Ok(response);
    }
}