using System.Text.Json;
using CostAccountingApp.ApplicationCore.Exceptions;

namespace CostAccountingApp.Web.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
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
        catch (CostAccountingAppException ex)
        {
            _logger.LogWarning(ex, ex.Message);
            HandleConcurrentModificationsException(context, ex);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Error, ex, ex.Message);

            SetTraceableUnhandeledErrorResponse(context);
        }
    }
    
    private static void SetTraceableUnhandeledErrorResponse(HttpContext context)
    {
        context.Response.Clear();
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
    }

    private static void HandleConcurrentModificationsException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = StatusCodes.Status409Conflict;
        
        context.Response.ContentType = "application/json";

        var errorJson = JsonSerializer.Serialize(exception.Message);
        context.Response.WriteAsync(errorJson);
    }
}