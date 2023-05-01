namespace PollutionPatrol.Modules.Admin.Application.SeedWork.Command;

public interface ICommand<out TResult> : IRequest<TResult>
{
}

public interface ICommand : IRequest
{
}