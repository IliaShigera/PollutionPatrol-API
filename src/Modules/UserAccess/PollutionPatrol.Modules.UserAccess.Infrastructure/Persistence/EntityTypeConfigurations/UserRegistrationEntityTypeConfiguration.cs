namespace PollutionPatrol.Modules.UserAccess.Infrastructure.Persistence.EntityTypeConfigurations;

internal sealed class UserRegistrationEntityTypeConfiguration : IEntityTypeConfiguration<UserRegistration>
{
    public void Configure(EntityTypeBuilder<UserRegistration> builder)
    {
        builder.ToTable("Registrations");
        
        builder.OwnsOne(r => r.Status, statusBuilder =>
            statusBuilder.Property(s => s.Value).HasColumnName("Status").IsRequired());
        
        builder.Property(x => x.FirstName).IsRequired();
        builder.Property(x => x.EmailAddress).IsRequired();
        builder.Property(x => x.PasswordHash).IsRequired();
        builder.Property(x => x.Salt).IsRequired();
        builder.Property(x => x.ConfirmationCode).IsRequired();
        builder.Property(x => x.RegistrationDate).IsRequired();
        builder.Property(x => x.ExpirationDate).IsRequired();
    }
}