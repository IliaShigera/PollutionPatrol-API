namespace PollutionPatrol.Modules.Pollution.Application.Contracts;

public interface IPollutionDbContext : IDbContext
{
    DbSet<PollutionReport> Reports { get; }
}