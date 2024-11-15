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
            HandleCostAccountingAppException(context, ex);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Error, ex, ex.Message);

            HandleGeneraException(context);
        }
    }
    
    private static void HandleGeneraException(HttpContext context)
    {
        context.Response.Clear();
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
    }

    private static void HandleCostAccountingAppException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = StatusCodes.Status409Conflict;
        
        context.Response.ContentType = "application/json";

        var errorJson = JsonSerializer.Serialize(exception.Message);
        context.Response.WriteAsync(errorJson);
    }
}
