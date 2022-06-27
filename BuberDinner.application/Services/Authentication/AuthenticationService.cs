using BuberDinner.application.Common.Interfaces.Auth;
using BuberDinner.application.Common.Interfaces.Persistence;
using BuberDinner.domain;
using BuberDinner.domain.Entities;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator jwtTokenGenerator;
    private readonly IUserRepository userRepository;

    public AuthenticationService(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        this.jwtTokenGenerator = jwtTokenGenerator;
        this.userRepository = userRepository;
    }
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        if (userRepository.GetUserByEmail(email) is not null)
        {
            throw new BuberDinnerException("User with given email already exists.");
        }

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password,
        };

        userRepository.Add(user);

        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        if (userRepository.GetUserByEmail(email) is not User user)
        {
            throw new BuberDinnerException("User with given email doesn't exist.");
        }
        
        if (user.Password != password)
        {
            throw new BuberDinnerException("Invalid password");
        }

        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}