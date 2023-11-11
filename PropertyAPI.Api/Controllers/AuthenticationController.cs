using PropertyAPI.Contract.Authentication;
using PropertyAPI.Application.Authentication.Common;
using PropertyAPI.Application.Authentication.Commands.Register;
using PropertyAPI.Application.Authentication.Queries.Login;
using PropertyAPI.Domain.Common.Errors;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using MediatR;

namespace PropertyAPI.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{

    private readonly ISender _mediator;
    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
        ErrorOr<AuthenticationResult> authCommandResult = await _mediator.Send(command);

        return authCommandResult.Match(
            authCommandResult => Ok(MapAuthResult(authCommandResult)),
            errors => Problem(errors)
        );

    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request){

        var query = new LoginQuery(request.Email,request.Password);
        ErrorOr<AuthenticationResult> authQueryResult = await _mediator.Send(query);
        
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