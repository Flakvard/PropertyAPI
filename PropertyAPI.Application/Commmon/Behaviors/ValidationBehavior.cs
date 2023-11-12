using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace PropertyAPI.Application.Commmon.Behaviors;

public class ValidateBehavior<TRequest, TResponse> :
IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly IValidator<TRequest>? _validator;

    public ValidateBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validator is null)
            return await next();

        var validationResult = await _validator.ValidateAsync(request,cancellationToken);

        if(validationResult.IsValid){
            return await next();
        }
        // Converting the errors for the ErrorOr
        var errors = validationResult.Errors
            .ConvertAll(ValidationFailure => Error.Validation(
                ValidationFailure.PropertyName,
                ValidationFailure.ErrorMessage));
        // (dynamic) compiler does not know there's a implicit conversion from a list of errors to the ErrorOr object
        // runtime check conversion - if not throws a runtime exception that gets captured at the ErrorController...
        return (dynamic)errors;

    }
}