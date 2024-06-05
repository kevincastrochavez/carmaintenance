using System.Net;

namespace CarMaintenance.Data;

public class ExceptionHandlerMiddleware
{
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;
    private readonly RequestDelegate _next;
    public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
    {
        this._logger = logger;
        this._next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
        catch (Exception ex)
        {
            var errorId = Guid.NewGuid();

            // Logging This Exception
            _logger.LogError(ex, $"{errorId} - Exception: {ex.Message}");

            // Return custom error response
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var error = new
            {
                Id = errorId,
                Message = "Something went wrong. Please try again later."
            };

            // Write error response
            await context.Response.WriteAsJsonAsync(error);
        }
    }
}