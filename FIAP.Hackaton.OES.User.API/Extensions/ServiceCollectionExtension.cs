using FIAP.Hackaton.OES.User.Infra.CorrelationId;

namespace FIAP.Hackaton.OES.User.API.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCorrelationIdGenerator(this IServiceCollection services)
    {
        services.AddTransient<ICorrelationIdGenerator, CorrelationIdGenerator>();

        return services;
    }
}
