namespace PollutionPatrol.Modules.UserAccess.Application.SeedWork.Command;

public interface ICommand<out TResult> : IRequest<TResult>
{
}

public interface ICommand : IRequest
{
}