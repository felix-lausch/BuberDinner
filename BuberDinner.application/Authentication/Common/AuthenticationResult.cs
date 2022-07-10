using BuberDinner.domain.Entities;

namespace BuberDinner.application.Services.Authentication.Common;

public record AuthenticationResult(
  User User,
  string Token
);