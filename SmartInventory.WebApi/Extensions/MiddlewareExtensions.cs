using SmartInventory.WebApi.Middleware;
using System.Runtime.CompilerServices;

namespace SmartInventory.WebApi.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder 
            UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionHandler>();
        }
    }
}
