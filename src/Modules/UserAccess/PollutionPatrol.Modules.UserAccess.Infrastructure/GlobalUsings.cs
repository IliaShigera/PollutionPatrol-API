// Global using directives

global using System.Reflection;
global using System.Security.Cryptography;
global using System.Text;
global using FluentValidation;
global using MediatR;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Design;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using PollutionPatrol.BuildingBlocks.Domain.Models;
global using PollutionPatrol.BuildingBlocks.Infrastructure.DomainEventsDispatching;
global using PollutionPatrol.Modules.UserAccess.Application.Contracts;
global using PollutionPatrol.Modules.UserAccess.Application.Features.Registration.Expiration;
global using PollutionPatrol.Modules.UserAccess.Application.SeedWork.Command;
global using PollutionPatrol.Modules.UserAccess.Application.SeedWork.Pipelines;
global using PollutionPatrol.Modules.UserAccess.Application.SeedWork.Query;
global using PollutionPatrol.Modules.UserAccess.Domain.AppUser;
global using PollutionPatrol.Modules.UserAccess.Domain.Registration;
global using PollutionPatrol.Modules.UserAccess.Infrastructure.Domain;
global using PollutionPatrol.Modules.UserAccess.Infrastructure.Persistence;
global using PollutionPatrol.Modules.UserAccess.Infrastructure.Persistence.EntityTypeConfigurations;
global using PollutionPatrol.Modules.UserAccess.Infrastructure.QuartzJobs;
global using PollutionPatrol.Modules.UserAccess.Infrastructure.Security;
global using Quartz;
global using Serilog;