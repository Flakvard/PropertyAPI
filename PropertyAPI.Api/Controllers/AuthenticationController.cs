using PropertyAPI.Contract.Authentication;
using PropertyAPI.Application.Authentication.Common;
using PropertyAPI.Application.Authentication.Commands.Register;
using PropertyAPI.Application.Authentication.Queries.Login;
using PropertyAPI.Domain.Common.Errors;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using MediatR;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;

namespace PropertyAPI.Api.Controllers;

[Route("auth")]
[AllowAnonymous] // ApiContoller has the [Authorize] attribute
public class AuthenticationController : ApiController
{

    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthenticationResult> authCommandResult = await _mediator.Send(command);

        return authCommandResult.Match(
            authCommandResult => Ok(_mapper.Map<AuthenticationResponse>(authCommandResult)),
            errors => Problem(errors)
        );

    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request){


        var query = _mapper.Map<LoginQuery>(request);
        ErrorOr<AuthenticationResult> authQueryResult = await _mediator.Send(query);
        
        if (authQueryResult.IsError && authQueryResult.FirstError == Errors.Authentication.InvalidCredentials){
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authQueryResult.FirstError.Description);
        }

        return authQueryResult.Match(
            authQueryResult => Ok(_mapper.Map<AuthenticationResponse>(authQueryResult)),
            errors => Problem(errors)
        );
    }

}