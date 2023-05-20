namespace TutorialPractise.Middleware
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Custom middleware starts\n");
            await next(context);
            await context.Response.WriteAsync("Custom Middleware end!\n");
        }
    }
    public static class CustomMiddlewareExtention
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomMiddleware>();
        }
    }
}
