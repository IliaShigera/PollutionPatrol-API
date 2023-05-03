﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PollutionPatrol.Modules.UserAccess.Infrastructure.Persistence;

#nullable disable

namespace PollutionPatrol.Modules.UserAccess.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(UserAccessDbContext))]
    partial class UserAccessDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PollutionPatrol.BuildingBlocks.Domain.Models.Entity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Entity");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("PollutionPatrol.Modules.UserAccess.Domain.AppUser.ApplicationUser", b =>
                {
                    b.HasBaseType("PollutionPatrol.BuildingBlocks.Domain.Models.Entity");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("PollutionPatrol.Modules.UserAccess.Domain.Registration.UserRegistration", b =>
                {
                    b.HasBaseType("PollutionPatrol.BuildingBlocks.Domain.Models.Entity");

                    b.Property<string>("ConfirmationCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ConfirmationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Registrations", (string)null);
                });

            modelBuilder.Entity("PollutionPatrol.Modules.UserAccess.Domain.AppUser.ApplicationUser", b =>
                {
                    b.HasOne("PollutionPatrol.BuildingBlocks.Domain.Models.Entity", null)
                        .WithOne()
                        .HasForeignKey("PollutionPatrol.Modules.UserAccess.Domain.AppUser.ApplicationUser", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("PollutionPatrol.Modules.UserAccess.Domain.AppUser.UserRole", "Roles", b1 =>
                        {
                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(450)")
                                .HasColumnName("Role");

                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Value", "UserId");

                            b1.HasIndex("UserId");

                            b1.ToTable("UserRole");

                            b1.WithOwner()
                                .HasForeignKey("UserId")
                                .HasConstraintName("FK_UserRole_User");
                        });

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("PollutionPatrol.Modules.UserAccess.Domain.Registration.UserRegistration", b =>
                {
                    b.HasOne("PollutionPatrol.BuildingBlocks.Domain.Models.Entity", null)
                        .WithOne()
                        .HasForeignKey("PollutionPatrol.Modules.UserAccess.Domain.Registration.UserRegistration", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("PollutionPatrol.Modules.UserAccess.Domain.Registration.RegistrationStatus", "Status", b1 =>
                        {
                            b1.Property<Guid>("UserRegistrationId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Status");

                            b1.HasKey("UserRegistrationId");

                            b1.ToTable("Registrations");

                            b1.WithOwner()
                                .HasForeignKey("UserRegistrationId");
                        });

                    b.Navigation("Status")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
