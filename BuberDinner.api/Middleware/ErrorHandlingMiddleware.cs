using System.Net;
using System.Text.Json;

namespace BuberDinner.api.Middleware;

//unused alternative to ErrorController
public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    public static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError; //500 if unexpected
        var result = JsonSerializer.Serialize(new { error = "An error occured while processing your request." });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        
        return context.Response.WriteAsync(result);
    }
}
