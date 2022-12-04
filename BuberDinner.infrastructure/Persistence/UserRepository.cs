using BuberDinner.application.Common.Interfaces.Persistence;
using BuberDinner.domain.User;

namespace BuberDinner.infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> users = new();

    public void Add(User user)
    {
        users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return users.SingleOrDefault(user => user.Email == email);
    }

    internal static void ClearRepo()
    {
        users.Clear();
    }
}
