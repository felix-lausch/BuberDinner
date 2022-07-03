using BuberDinner.Application;
using BuberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);
    
    //builder.Services.AddControllers(builder => builder.Filters.Add<ErrorHandlingFilterAttribute>()); // Exception Handling via Attribute
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    //app.UseMiddleware<ErrorHandlingMiddleware>();// Exception handling via middleware
    //app.UseExceptionHandler("/error"); // Exception handling via error controller
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

