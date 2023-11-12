using ErrorOr;
using MediatR;
using PropertyAPI.Application.Authentication.Common;

namespace PropertyAPI.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>; // The data we need is RegisterCommand, and it returns ErrorOr<AuthenticationResult> 
