using PropertyAPI.Domain.Entities;

namespace PropertyAPI.Application.Commmon.Interfaces.Persistence;

public interface IUserRepository{

    User? GetUserByEmail(string email);
    void Add(User user);
}