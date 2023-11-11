using System.Reflection.Metadata.Ecma335;
using PropertyAPI.Domain.Entities;

namespace PropertyAPI.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token
);