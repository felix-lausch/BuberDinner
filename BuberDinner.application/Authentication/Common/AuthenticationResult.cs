using BuberDinner.domain.User;

namespace BuberDinner.application.Services.Authentication.Common;

public record AuthenticationResult(
  User User,
  string Token
);