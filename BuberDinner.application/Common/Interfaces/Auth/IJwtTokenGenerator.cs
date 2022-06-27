using BuberDinner.domain.Entities;

namespace BuberDinner.application.Common.Interfaces.Auth;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
