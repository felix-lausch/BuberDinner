namespace BuberDinner.application.Common.Interfaces.Persistence;

using BuberDinner.domain.User;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}
