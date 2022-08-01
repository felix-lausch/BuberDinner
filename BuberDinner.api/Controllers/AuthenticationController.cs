namespace BuberDinner.Api.Controllers;

using BuberDinner.api.Controllers;
using BuberDinner.api.Filters;
using BuberDinner.application.Authentication.Commands;
using BuberDinner.application.Authentication.Queries;
using BuberDinner.application.Services.Authentication.Common;
using BuberDinner.Contracts.Authentication;
using BuberDinner.domain.Common.Errors;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender mediatr;
    private readonly IMapper mapper;

    public AuthenticationController(IMapper mapper, ISender mediatr)
    {
        this.mapper = mapper;
        this.mediatr = mediatr;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var registerCommand = mapper.Map<RegisterCommand>(request);

        var registerResult = await mediatr.Send(registerCommand);

        return registerResult.Match(
            authResult => Ok(mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var loginQuery = new LoginQuery(
            request.Email,
            request.Password);

        var loginResult = await mediatr.Send(loginQuery);

        if (loginResult.IsError && loginResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: loginResult.FirstError.Description);
        }

        return loginResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token);
    }
}