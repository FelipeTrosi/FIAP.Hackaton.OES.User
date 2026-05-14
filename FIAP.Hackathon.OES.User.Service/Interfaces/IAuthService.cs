using FIAP.Hackathon.OES.User.Service.ServiceToken;
using IAP.Hackathon.OES.User.Service.Dto.Login;

namespace FIAP.Hackathon.OES.User.Service.Interfaces;

public interface IAuthService
{
    string Login(LoginDto input);
    string WorkerLogin(ServiceTokenRequest request);
}
