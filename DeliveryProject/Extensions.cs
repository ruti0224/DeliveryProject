using DeliveryProject.Middleware;

namespace DeliveryProject
{
    public static class Extensions
    {
        public static IApplicationBuilder UseShabbatMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ShabbatMiddleware>();
        }
    }
}
