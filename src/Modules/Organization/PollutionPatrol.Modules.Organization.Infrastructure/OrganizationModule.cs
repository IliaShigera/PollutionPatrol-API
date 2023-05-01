namespace PollutionPatrol.Modules.Organization.Infrastructure;

internal sealed class OrganizationModule : IOrganizationModule
{
    private readonly IMediator _mediator;

    public OrganizationModule(IMediator mediator) => _mediator = mediator;

    public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default) =>
        await _mediator.Send(command, cancellationToken);

    public async Task ExecuteCommandAsync(ICommand command, CancellationToken cancellationToken = default) =>
        await _mediator.Send(command, cancellationToken);

    public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default) =>
        await _mediator.Send(query, cancellationToken);
}