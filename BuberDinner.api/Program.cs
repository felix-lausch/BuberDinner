using BuberDinner.api;
using BuberDinner.Application;
using BuberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    // app.UseMiddleware<ErrorHandlingMiddleware>();// Exception handling via middleware
    app.UseExceptionHandler("/error"); // Exception handling via error controller
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}