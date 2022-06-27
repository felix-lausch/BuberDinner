namespace BuberDinner.Infrastructure;

using BuberDinner.application.Common.Interfaces.Auth;
using BuberDinner.application.Common.Interfaces.Persistence;
using BuberDinner.application.Common.Interfaces.Services;
using BuberDinner.infrastructure.Auth;
using BuberDinner.infrastructure.Persistence;
using BuberDinner.infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependenecyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}