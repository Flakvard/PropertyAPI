using PropertyAPI.Application.Commmon.Interfaces.Authentication;

namespace PropertyAPI.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Login(string Email, string Password){
        return new AuthenticationResult(
            Guid.NewGuid(),
            "FirstName",
            "LastName",
            Email,
            "token"
            );
    }
    public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password){
        // Check if user exist

        // Create a user (Generate unique ID)

        // Create JWT Token
        Guid userid = Guid.NewGuid();

        var token = _jwtTokenGenerator.GenerateToken(userid,FirstName,LastName);
        
        return new AuthenticationResult(
            userid,
            FirstName,
            LastName,
            Email,
            token);
    }
}