﻿namespace PollutionPatrol.Modules.Organization.Infrastructure.Persistence;

internal sealed class OrganizationDbContext : DbContext, IOrganizationDbContext
{
    private readonly IDomainEventsDispatcher _eventsDispatcher;

    public OrganizationDbContext(DbContextOptions<OrganizationDbContext> options, IDomainEventsDispatcher eventsDispatcher)
        : base(options)
    {
        _eventsDispatcher = eventsDispatcher;
    }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await SaveChangesAsync(cancellationToken);

        await _eventsDispatcher.DispatchEventsAsync(this, cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EntityTypeConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}