using System.Net;
using System.Text.Json;
using BooksFinderApp.API.Errors;

namespace BooksFinderApp.API.Middleware;

public class GlobalExceptionHandler(RequestDelegate _next, ILogger<GlobalExceptionHandler> _logger)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(httpContext, e.Message, HttpStatusCode.InternalServerError,
                "Internal server error");
        }
    }

    private async Task HandleExceptionAsync(
        HttpContext context,
        string exMsg,
        HttpStatusCode httpStatusCode,
        string message)
    {
        _logger.LogError(exMsg);

        HttpResponse response = context.Response;

        response.ContentType = "application/json";
        response.StatusCode = (int)httpStatusCode;

        ErrorDto errorDto = new()
        {
            Message = message,
            StatusCode = (int)httpStatusCode
        };

        string result = JsonSerializer.Serialize(errorDto);

        await response.WriteAsJsonAsync(result);
    }
}