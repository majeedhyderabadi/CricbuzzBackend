using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MatchApi.Api.ExceptionHandling;

/// <summary>
/// Catch-all safety net for exceptions that escape individual endpoint handlers (which already
/// handle their own expected ValidationException/InvalidOperationException cases). Logs the full
/// exception via the configured Serilog sinks (console / Application Insights) and returns a
/// ProblemDetails response instead of leaking a stack trace to the client.
/// </summary>
public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;
    private readonly IHostEnvironment _environment;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, IHostEnvironment environment)
    {
        _logger = logger;
        _environment = environment;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var (statusCode, title) = MapException(exception);

        _logger.LogError(
            exception,
            "Unhandled exception on {Method} {Path} (TraceId: {TraceId})",
            httpContext.Request.Method,
            httpContext.Request.Path,
            httpContext.TraceIdentifier);

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = _environment.IsDevelopment() ? exception.ToString() : exception.Message,
            Instance = httpContext.Request.Path
        };
        problemDetails.Extensions["traceId"] = httpContext.TraceIdentifier;

        httpContext.Response.StatusCode = statusCode;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }

    private static (int StatusCode, string Title) MapException(Exception exception) => exception switch
    {
        InvalidOperationException => (StatusCodes.Status400BadRequest, "Bad Request"),
        UnauthorizedAccessException => (StatusCodes.Status401Unauthorized, "Unauthorized"),
        KeyNotFoundException => (StatusCodes.Status404NotFound, "Not Found"),
        _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred")
    };
}
