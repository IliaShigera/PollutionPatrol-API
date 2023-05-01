namespace PollutionPatrol.Modules.Organization.Application.SeedWork.Command;

internal interface ICommandHandler<in TCommand, TResult> :
    IRequestHandler<TCommand, TResult>
    where TCommand : ICommand<TResult>
{
}

internal interface ICommandHandler<in TCommand> :
    IRequestHandler<TCommand>
    where TCommand : ICommand
{
}