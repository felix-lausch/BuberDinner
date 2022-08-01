namespace BuberDinner.api;

using BuberDinner.api.Common.Mapping;
using BuberDinner.api.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

public static class DependenecyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMappings();

        //builder.Services.AddControllers(builder => builder.Filters.Add<ErrorHandlingFilterAttribute>()); // Exception Handling via Attribute
        services.AddControllers();

        services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
        return services;
    }
}