using FIAP.Hackathon.OES.User.API.Services;
using FIAP.Hackathon.OES.User.Infra.Logger;
using FIAP.Hackathon.OES.User.Service.Interfaces;
using FIAP.Hackathon.OES.User.Service.Services;

namespace FIAP.Hackathon.OES.User.API.Extensions; 

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
