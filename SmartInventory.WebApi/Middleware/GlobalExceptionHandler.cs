
using System.Net;
using System.Text.Json;

namespace SmartInventory.WebApi.Middleware
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(
            RequestDelegate next,
            ILogger<GlobalExceptionHandler> logger)
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
                _logger.LogError(
                    ex,
                    "An unexpected error occurred: {Message}",
                    ex.Message
                );

                if (context.Response.HasStarted)
                {
                    throw;
                }

                context.Response.Clear();
                context.Response.StatusCode =
                    (int)HttpStatusCode.InternalServerError;

                context.Response.ContentType = "application/json";

                var response = new
                {
                    Success = false,
                    Message = "An internal server error occurred.",
                    Details = context.RequestServices
                        .GetRequiredService<IWebHostEnvironment>()
                        .IsDevelopment()
                            ? ex.ToString()
                            : null
                };

                var jsonOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };

                var jsonResponse = JsonSerializer.Serialize(
                    response,
                    jsonOptions
                );

                await context.Response.WriteAsync(jsonResponse);
            }
        }
    }
}
