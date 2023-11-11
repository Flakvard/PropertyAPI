using ErrorOr;
using PropertyAPI.Application.Commmon.Interfaces.Authentication;
using PropertyAPI.Application.Commmon.Interfaces.Persistence;
using PropertyAPI.Application.Services.Authentication.Common;
using PropertyAPI.Domain.Common.Errors;
using PropertyAPI.Domain.Entities;

namespace PropertyAPI.Application.Services.Authentication.Commands;

public class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Register(string firstname, string lastname, string email, string password)
    {
        // 1. Validate the user doesn't exist
        if (_userRepository.GetUserByEmail(email) is not null)
            return Errors.User.DuplicateEmail;

        // 2. Create a user (Generate unique ID) and Persist to DB
        var user = new User
        {
            FirstName = firstname,
            LastName = lastname,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        // 3. Create JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}