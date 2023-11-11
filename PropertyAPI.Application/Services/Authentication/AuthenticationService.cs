using ErrorOr;
using PropertyAPI.Application.Commmon.Interfaces.Authentication;
using PropertyAPI.Application.Commmon.Interfaces.Persistence;
using PropertyAPI.Domain.Common.Errors;
using PropertyAPI.Domain.Entities;

namespace PropertyAPI.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Login(string email, string password){

        // 1. Validate the user does exist
        if(_userRepository.GetUserByEmail(email) is not User user)
                return Errors.Authentication.InvalidCredentials;

        // 2. Validate the password is correct
        if(user.Password != password)
                return new[] {Errors.Authentication.InvalidCredentials};

        // 3. Create JwtToken 
        var token = _jwtTokenGenerator.GenerateToken(user);


        return new AuthenticationResult(
            user,
            token
            );
    }
    public ErrorOr<AuthenticationResult> Register(string firstname, string lastname, string email, string password){
        // 1. Validate the user doesn't exist
        if(_userRepository.GetUserByEmail(email) is not null)
            return Errors.User.DuplicateEmail;

        // 2. Create a user (Generate unique ID) and Persist to DB
        var user = new User{
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