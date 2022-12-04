using BuberDinner.application.Services.Authentication.Common;
using ErrorOr;
using MediatR;

namespace BuberDinner.application.Authentication.Queries;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;