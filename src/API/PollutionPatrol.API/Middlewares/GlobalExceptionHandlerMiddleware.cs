using AuthenticationException = PollutionPatrol.BuildingBlocks.Application.Exceptions.AuthenticationException;
using ILogger = Serilog.ILogger;

namespace PollutionPatrol.API.Middlewares;

public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, ex.Message);

            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var details = GetProblemDetails(context, ex);
        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = details.Status!.Value;
        return context.Response.WriteAsync(JsonConvert.SerializeObject(details));
    }

    private ProblemDetails GetProblemDetails(HttpContext context, Exception ex) => ex switch
    {
        #region 400

        InvalidMessageException exception => new ValidationProblemDetails(exception.Errors)
        {
            Title = "Invalid request",
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            Detail = "The request is invalid. Please verify the request and try again.",
            Status = StatusCodes.Status400BadRequest,
            Instance = context.Request.Path
        },

        BadRequestException exception => new ProblemDetails
        {
            Title = "Bad request",
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            Detail = exception.Details,
            Status = StatusCodes.Status400BadRequest,
            Instance = context.Request.Path
        },

        SpecNotFoundException => new ProblemDetails
        {
            Title = "Specification not found in database",
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            Detail = "Sorry, but the specification you were looking for doesn't seem to be in our database." +
                     " Please verify the request and try again.",
            Status = StatusCodes.Status400BadRequest,
            Instance = context.Request.Path
        },

        DomainRuleBrokenException exception => new ProblemDetails
        {
            Title = "Bad request",
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            Detail = exception.Details,
            Status = StatusCodes.Status400BadRequest,
            Instance = context.Request.Path
        },

        #endregion

        #region 401

        AuthenticationException exception => new ProblemDetails
        {
            Title = "Unauthenticated",
            Type = "https://www.rfc-editor.org/rfc/rfc7235#section-3.1",
            Detail = exception.Details,
            Status = StatusCodes.Status401Unauthorized,
            Instance = context.Request.Path
        },

        SecurityTokenException => new ProblemDetails
        {
            Title = "Invalid or expired security token",
            Type = "https://www.rfc-editor.org/rfc/rfc7235#section-3.1",
            Detail = "The provided security token is invalid or has expired.",
            Status = StatusCodes.Status401Unauthorized,
            Instance = context.Request.Path
        },

        #endregion

        #region 403

        AuthorizationException => new ProblemDetails
        {
            Title = "Unauthorized",
            Type = "https://www.rfc-editor.org/rfc/rfc7231#section-6.5.3",
            Detail = "The request requires user authorization.",
            Status = StatusCodes.Status403Forbidden,
            Instance = context.Request.Path
        },

        #endregion

        #region 404

        DropboxException exception when exception.Message.StartsWith("path_lookup/not_found/")
                                        || exception.Message.StartsWith("path/not_found/") => new ProblemDetails
        {
            Type = "https://www.rfc-editor.org/rfc/rfc7231#section-6.5.4",
            Title = "The specified file or folder was not found on Dropbox.",
            Status = StatusCodes.Status404NotFound,
            Detail = "Please verify that the file or folder exists and that you have permission to access it.",
            Instance = context.Request.Path
        },

        DropboxException => new ProblemDetails
        {
            Type = "https://www.rfc-editor.org/rfc/rfc7231#section-6.5.4",
            Title = "An error occurred while communicating with Dropbox.",
            Status = StatusCodes.Status404NotFound,
            Detail = "Please try again later or contact support if the problem persists.",
            Instance = context.Request.Path
        },

        #endregion

        #region 500

        _ => new ProblemDetails
        {
            Title = "Internal server error",
            Type = "https://www.rfc-editor.org/rfc/rfc7231#section-6.6.1",
            Detail = "An internal server error has occurred. Please try again later.",
            Status = StatusCodes.Status500InternalServerError,
            Instance = context.Request.Path
        }

        #endregion
    };
}