namespace PollutionPatrol.Modules.Pollution.Infrastructure;

internal sealed class PollutionModule : IPollutionModule
{
    private readonly IMediator _mediator;

    public PollutionModule(IMediator mediator) => _mediator = mediator;

    public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default) =>
        await _mediator.Send(command, cancellationToken);

    public async Task ExecuteCommandAsync(ICommand command, CancellationToken cancellationToken = default) =>
        await _mediator.Send(command, cancellationToken);

    public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default) =>
        await _mediator.Send(query, cancellationToken);
}