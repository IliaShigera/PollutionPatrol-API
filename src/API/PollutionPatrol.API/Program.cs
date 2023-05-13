using PollutionPatrol.BuildingBlocks.Media.Access;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up!");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((context, services, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()
        .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
        .WriteTo.File(new CompactJsonFormatter(), "logs/logs"));

    // Add services to the container.
    ConfigureServices(builder.Services, builder.Configuration);
    var app = builder.Build();
    // Configure the HTTP request pipeline.
    Configure(app);
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerDoc();
    services.AddCurrentUserAccessor();

    services.AddCors(options =>
    {
        options.AddDefaultPolicy(builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });

    services.AddAuthentication(configuration);

    services.AddBuildingBlocks(configuration);
    services.AddExternalMediaStorageAccess();
    services.AddEmailNotifications();
    services.AddUserAccessModule(configuration);
}


void Configure(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwaggerDoc();
    }

    app.UseSerilogRequestLogging();

    app.UseGlobalExceptionHandler();

    app.UseHttpsRedirection();

    app.UseCors();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}