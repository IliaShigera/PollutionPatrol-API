namespace PollutionPatrol.Modules.Monitoring.Application.SeedWork.Pipelines;

internal sealed class LoggingPipelineBehaviour<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ILogger _logger;

    public LoggingPipelineBehaviour(ILogger logger) => _logger = logger;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.Information($"[Monitoring Module] Handling {typeof(TRequest).Name}");
#if DEBUG
        _logger.Information($"[Props] {JsonConvert.SerializeObject(request)}");
#endif
        var response = await next();

        _logger.Information($"[Monitoring Module]: Handled {typeof(TRequest).Name}");

        return response;
    }
}