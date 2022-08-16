namespace BuberDinner.Application;

using BuberDinner.application.Common.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

public static class DependenecyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependenecyInjection).Assembly);
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}