namespace PollutionPatrol.Modules.Pollution.Infrastructure.Persistence.EntityTypeConfigurations;

internal sealed class EntityTypeConfiguration : IEntityTypeConfiguration<Entity>
{
    public void Configure(EntityTypeBuilder<Entity> builder)
    {
        // Ignore the DomainEvents property
        builder.Ignore(x => x.DomainEvents);
    }
}