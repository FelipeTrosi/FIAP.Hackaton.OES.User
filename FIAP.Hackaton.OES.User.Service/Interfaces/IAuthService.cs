using IAP.Hackaton.OES.User.Service.Dto.Login;

namespace FIAP.Hackaton.OES.User.Service.Interfaces;

public interface IAuthService
{
    string Login(LoginDto input);
}
