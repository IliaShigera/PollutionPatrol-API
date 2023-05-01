namespace PollutionPatrol.Modules.Monitoring.Application.SeedWork.Query;

internal interface IQueryHandler<in TQuery, TResult> :
    IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
}