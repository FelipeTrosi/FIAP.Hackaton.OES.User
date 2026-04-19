
using FIAP.Hackaton.OES.User.Infra.Repository;
using FIAP.Hackaton.OES.User.Infra.Repository.Interfaces;

namespace FIAP.Hackaton.OES.User.API.Extensions
{
    public static class RepositoryDIExtension
    {
        public static IServiceCollection AddRepositoryDI(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
