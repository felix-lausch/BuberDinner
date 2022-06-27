using BuberDinner.Application;
using BuberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);
    
    //builder.Services.AddControllers(builder => builder.Filters.Add<ErrorHandlingFilterAttribute>()); // UseExceptionHandler replaces this Attribute
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    //app.UseMiddleware<ErrorHandlingMiddleware>(); UseExceptionHandler replaces this middleware
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

