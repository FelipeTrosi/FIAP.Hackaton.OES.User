using FIAP.Hackaton.OES.User.API.Services;
using FIAP.Hackaton.OES.User.Infra.Logger;
using FIAP.Hackaton.OES.User.Service.Interfaces;
using FIAP.Hackaton.OES.User.Service.Services;

namespace FIAP.Hackaton.OES.User.API.Extensions; 

public static class ServiceDIExtension
{
    public static IServiceCollection AddServiceDI(this IServiceCollection services)
    {
        services.AddTransient(typeof(IBaseLogger<>), typeof(BaseLogger<>));

        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IAuthService, AuthService>();

        return services;
    }
}
