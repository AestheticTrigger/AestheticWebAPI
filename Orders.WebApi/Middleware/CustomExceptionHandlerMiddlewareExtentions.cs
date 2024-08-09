using Microsoft.AspNetCore.Builder;

namespace Orders.WebApi.Middleware
{
    public static class CustomExceptionHandlerMiddlewareExtentions
    {
        public static IApplicationBuilder UseCustomExceptionHandler (this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
