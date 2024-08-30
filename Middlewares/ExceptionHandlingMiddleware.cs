using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using PhoneBook.Exceptions;

namespace PhoneBook.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        logger.LogError(exception, exception.Message);

        var result = exception switch
        {
            NotFoundException => new { Message = exception.Message, StatusCode = StatusCodes.Status404NotFound },
            _ => new { Message = "An unexpected error occurred.", StatusCode = StatusCodes.Status500InternalServerError }
        };

        await context.Response.WriteAsJsonAsync(result);
    }
}
