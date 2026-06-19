using Dating.API.Errors;
using System.Net;
using System.Text.Json;

namespace Dating.API.Middleware;

public class ExceptionMiddleware(RequestDelegate next,
                                 ILogger<ExceptionMiddleware> logger,
                                 IHostEnvironment environment)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "{message}", exception.Message);

            context.Response.ContentType = "application/json";

            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

            var response = environment.IsDevelopment()
                ? new APIException(context.Response.StatusCode, exception.Message, exception.StackTrace?.ToString())
                : new APIException(context.Response.StatusCode, "Internal Server Error");

            var options = new JsonSerializerOptions 
            { 
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase 
            };

            var json = JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(json);
        }
    }
}
