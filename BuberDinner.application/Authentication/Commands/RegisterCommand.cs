namespace BuberDinner.application.Authentication.Commands;

using BuberDinner.application.Services.Authentication.Common;
using ErrorOr;
using MediatR;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
