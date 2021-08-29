using LoggingService.CustomExceptionMiddleware;
using Microsoft.AspNetCore.Builder;

namespace IssueTracker.API.Extenstion
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
