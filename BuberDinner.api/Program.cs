using BuberDinner.api.Errors;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    
    //builder.Services.AddControllers(builder => builder.Filters.Add<ErrorHandlingFilterAttribute>()); // Exception Handling via Attribute
    builder.Services.AddControllers();

    builder.Services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
}

var app = builder.Build();
{
    //app.UseMiddleware<ErrorHandlingMiddleware>();// Exception handling via middleware
    app.UseExceptionHandler("/error"); // Exception handling via error controller
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}