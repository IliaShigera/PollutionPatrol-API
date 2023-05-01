namespace PollutionPatrol.Modules.Pollution.Application.SeedWork.Query;

internal interface IQueryHandler<in TQuery, TResult> :
    IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
}