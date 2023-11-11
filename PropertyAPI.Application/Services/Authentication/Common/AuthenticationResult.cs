using PropertyAPI.Domain.Entities;

namespace PropertyAPI.Application.Services.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
);