
using FIAP.Hackaton.OES.User.API.Middleware;

namespace FIAP.Hackaton.OES.User.API.Extensions;

public static class LogMiddlewareExtensions
{
    public static IApplicationBuilder UseLogMiddleware(this IApplicationBuilder builder)
        => builder.UseMiddleware<LogMiddleware>();

}