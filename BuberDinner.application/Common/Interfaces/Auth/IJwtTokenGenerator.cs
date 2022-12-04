using BuberDinner.domain.User;

namespace BuberDinner.application.Common.Interfaces.Auth;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
