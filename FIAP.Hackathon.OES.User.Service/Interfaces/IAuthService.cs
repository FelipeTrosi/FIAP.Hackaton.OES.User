using IAP.Hackathon.OES.User.Service.Dto.Login;

namespace FIAP.Hackathon.OES.User.Service.Interfaces;

public interface IAuthService
{
    string Login(LoginDto input);
}
