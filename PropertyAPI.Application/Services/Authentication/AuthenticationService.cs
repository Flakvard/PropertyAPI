using System;
using System.Security.Principal;
using PropertyAPI.Application.Commmon.Interfaces.Authentication;
using PropertyAPI.Application.Commmon.Interfaces.Persistence;
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

    public AuthenticationResult Login(string email, string password){

        // 1. Validate the user does exist
        if(_userRepository.GetUserByEmail(email) is not User user)
                throw new Exception("User email already exists");

        // 2. Validate the password is correct
        if(user.Password != password)
                throw new Exception("Invalid password");

        // 3. Create JwtToken 
        var token = _jwtTokenGenerator.GenerateToken(user);


        return new AuthenticationResult(
            user,
            token
            );
    }
    public AuthenticationResult Register(string firstname, string lastname, string email, string password){
        // 1. Validate the user doesn't exist
        if(_userRepository.GetUserByEmail(email) is not null)
                throw new Exception("User email already exists");

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