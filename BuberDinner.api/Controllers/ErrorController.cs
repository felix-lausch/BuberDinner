namespace BuberDinner.api.Controllers;

using BuberDinner.domain;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

public class ErrorController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        return exception switch
        {
            BuberDinnerException => Problem(title: exception?.Message, statusCode: 400),
            _ => Problem(statusCode: 500),
        };
    }
}
