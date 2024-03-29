namespace BuberDinner.Infrastructure;

using BuberDinner.application.Common.Interfaces.Auth;
using BuberDinner.application.Common.Interfaces.Persistence;
using BuberDinner.application.Common.Interfaces.Services;
using BuberDinner.infrastructure.Auth;
using BuberDinner.infrastructure.Persistence;
using BuberDinner.infrastructure.Persistence.Repositories;
using BuberDinner.infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddDbContext<BuberDinnerDbContext>(options => options.UseSqlServer("Server=localhost;Database=BuberDinner;Integrated Security=True;Encrypt=false"));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();

        return services;
    }
}