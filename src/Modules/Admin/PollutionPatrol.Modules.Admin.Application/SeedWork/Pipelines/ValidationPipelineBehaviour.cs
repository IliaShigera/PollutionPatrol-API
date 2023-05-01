namespace PollutionPatrol.Modules.Admin.Application.SeedWork.Pipelines;

internal sealed class ValidationPipelineBehaviour<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IValidator<TRequest> _validator;

    public ValidationPipelineBehaviour(IValidator<TRequest> validator) => _validator = validator;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.ToDictionary();
            throw new InvalidMessageException(errors);
        }

        return await next();
    }
}