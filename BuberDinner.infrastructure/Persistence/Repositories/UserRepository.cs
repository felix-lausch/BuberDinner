using BuberDinner.application.Common.Interfaces.Persistence;
using BuberDinner.domain.UserAggregate;

namespace BuberDinner.infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private static readonly List<User> Users = new();

    public void Add(User user)
    {
        Users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return Users.SingleOrDefault(user => user.Email == email);
    }

    internal static void ClearRepo()
    {
        Users.Clear();
    }
}
