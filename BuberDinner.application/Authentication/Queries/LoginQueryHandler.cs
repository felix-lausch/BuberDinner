namespace BuberDinner.application.Authentication.Queries;

using BuberDinner.application.Common.Interfaces.Auth;
using BuberDinner.application.Common.Interfaces.Persistence;
using BuberDinner.application.Services.Authentication.Common;
using BuberDinner.domain.Common.Errors;
using BuberDinner.domain.Entities;
using ErrorOr;
using MediatR;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator jwtTokenGenerator;
    private readonly IUserRepository userRepository;

    public LoginQueryHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        this.jwtTokenGenerator = jwtTokenGenerator;
        this.userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        if (userRepository.GetUserByEmail(query.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (user.Password != query.Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}
