namespace PollutionPatrol.Modules.Support.Application.SeedWork.Query;

internal interface IQueryHandler<in TQuery, TResult> :
    IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
}