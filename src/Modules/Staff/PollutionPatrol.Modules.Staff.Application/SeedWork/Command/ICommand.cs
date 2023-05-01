namespace PollutionPatrol.Modules.Staff.Application.SeedWork.Command;

public interface ICommand<out TResult> : IRequest<TResult>
{
}

public interface ICommand : IRequest
{
}