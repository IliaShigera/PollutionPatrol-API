// Global using directives

global using System.Security.Authentication;
global using System.Security.Claims;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;
global using Newtonsoft.Json;
global using PollutionPatrol.API.CurrentUserAccess;
global using PollutionPatrol.API.Extensions;
global using PollutionPatrol.API.Middlewares;
global using PollutionPatrol.API.Models;
global using PollutionPatrol.BuildingBlocks.Application.Exceptions;
global using PollutionPatrol.BuildingBlocks.Application.Interfaces;
global using PollutionPatrol.BuildingBlocks.Domain.Exceptions;
global using PollutionPatrol.BuildingBlocks.Infrastructure;
global using PollutionPatrol.BuildingBlocks.Notification.Email;
global using PollutionPatrol.Modules.UserAccess.Application.Contracts;
global using PollutionPatrol.Modules.UserAccess.Application.Features.Registration;
global using PollutionPatrol.Modules.UserAccess.Application.Features.Registration.Confirmation;
global using PollutionPatrol.Modules.UserAccess.Infrastructure;
global using PollutionPatrol.Modules.UserAccess.Infrastructure.Security;
global using Serilog;
global using Serilog.Formatting.Compact;