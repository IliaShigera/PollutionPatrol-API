// Global using directives

global using System.Reflection;
global using FluentValidation;
global using MediatR;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Design;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using PollutionPatrol.BuildingBlocks.Domain.Models;
global using PollutionPatrol.BuildingBlocks.Infrastructure.DomainEventsDispatching;
global using PollutionPatrol.Modules.Monitoring.Application.Contracts;
global using PollutionPatrol.Modules.Monitoring.Application.SeedWork.Command;
global using PollutionPatrol.Modules.Monitoring.Application.SeedWork.Pipelines;
global using PollutionPatrol.Modules.Monitoring.Application.SeedWork.Query;
global using PollutionPatrol.Modules.Monitoring.Infrastructure.Persistence;
global using PollutionPatrol.Modules.Monitoring.Infrastructure.Persistence.EntityTypeConfigurations;