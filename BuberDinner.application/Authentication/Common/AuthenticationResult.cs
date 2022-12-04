using BuberDinner.domain.UserAggregate;

namespace BuberDinner.application.Services.Authentication.Common;

public record AuthenticationResult(
  User User,
  string Token
);