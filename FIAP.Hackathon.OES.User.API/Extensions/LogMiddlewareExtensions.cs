
using FIAP.Hackathon.OES.User.API.Middleware;

namespace FIAP.Hackathon.OES.User.API.Extensions;

public static class LogMiddlewareExtensions
{
    public static IApplicationBuilder UseLogMiddleware(this IApplicationBuilder builder)
        => builder.UseMiddleware<LogMiddleware>();

}