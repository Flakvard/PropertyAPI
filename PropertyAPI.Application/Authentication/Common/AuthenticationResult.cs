using ErrorOr;
using MediatR;
using PropertyAPI.Domain.Entities;

namespace PropertyAPI.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
) : IRequest<ErrorOr<AuthenticationResult>>;