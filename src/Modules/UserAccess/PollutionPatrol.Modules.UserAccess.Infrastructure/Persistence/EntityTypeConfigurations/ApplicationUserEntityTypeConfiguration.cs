namespace PollutionPatrol.Modules.UserAccess.Infrastructure.Persistence.EntityTypeConfigurations;

internal sealed class ApplicationUserEntityTypeConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("Users");
        
        builder.OwnsMany(u => u.Roles, roleBuilder =>
        {
            roleBuilder.Property(r => r.Value)
                .HasColumnName("Role")
                .IsRequired();

            roleBuilder.WithOwner()
                .HasForeignKey("UserId")
                .HasConstraintName("FK_UserRole_User");

            roleBuilder.HasKey("Value", "UserId");
        });

        builder.Property(x => x.FirstName).IsRequired();
        builder.Property(x => x.EmailAddress).IsRequired();
        builder.Property(x => x.PasswordHash).IsRequired();
        builder.Property(x => x.Salt).IsRequired();
    }
}