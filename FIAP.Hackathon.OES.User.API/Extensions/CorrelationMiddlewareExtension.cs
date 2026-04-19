
using FIAP.Hackathon.OES.User.API.Middlewares;

namespace FIAP.Hackathon.OES.User.API.Extensions;

public static class CorrelationMiddlewareExtension
{
    public static IApplicationBuilder UseCorrelationMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CorrelationMiddleware>();
    }
}
