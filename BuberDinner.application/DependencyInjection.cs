namespace BuberDinner.Application;

using MediatR;
using Microsoft.Extensions.DependencyInjection;

public static class DependenecyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependenecyInjection).Assembly);
        return services;
    }
}