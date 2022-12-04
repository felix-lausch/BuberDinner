using BuberDinner.domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace BuberDinner.api.Filters;

// Unused alternative to ErrorController
public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        var statusCode = exception switch
        {
            BuberDinnerException => HttpStatusCode.BadRequest,
            _ => HttpStatusCode.InternalServerError,
        };

        var problemDetails = new ProblemDetails
        {
            Title = exception.Message,
            Status = (int)statusCode,
        };

        context.Result = new ObjectResult(problemDetails);

        context.ExceptionHandled = true;
    }
}
