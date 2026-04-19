
using FIAP.Hackathon.OES.User.Infra.Repository;
using FIAP.Hackathon.OES.User.Infra.Repository.Interfaces;

namespace FIAP.Hackathon.OES.User.API.Extensions
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
