namespace BuberDinner.application.Common.Behaviors;

using BuberDinner.application.Authentication.Commands;
using BuberDinner.application.Services.Authentication.Common;
using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly IValidator<TRequest>? validator;

    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        this.validator = validator;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        if (validator is null)
        {
            return await next();
        }

        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            return await next();
        }

        var errors = validationResult.Errors
            .ConvertAll(error => Error.Validation(error.PropertyName, error.ErrorMessage));

        return (dynamic)errors;
    }
}
