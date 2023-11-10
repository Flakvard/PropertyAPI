namespace PropertyAPI.Contract.Authentication;
public record LoginRequest(
    string Email,
    string Password);