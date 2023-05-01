namespace PollutionPatrol.API.Extensions;

public static class WebApplicationExtensions
{
    public static void UseGlobalExceptionHandler(this WebApplication app) =>
        app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
    
    public static void UseSwaggerDoc(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}