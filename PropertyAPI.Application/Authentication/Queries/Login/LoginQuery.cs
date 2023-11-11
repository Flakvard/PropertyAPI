using ErrorOr;
using MediatR;
using PropertyAPI.Application.Authentication.Common;

namespace PropertyAPI.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>; // The data we need is RegisterCommand, and it returns ErrorOr<AuthenticationResult> 