using FIAP.Hackathon.OES.User.Infra.CorrelationId;

namespace FIAP.Hackathon.OES.User.API.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCorrelationIdGenerator(this IServiceCollection services)
    {
        services.AddTransient<ICorrelationIdGenerator, CorrelationIdGenerator>();

        return services;
    }
}
