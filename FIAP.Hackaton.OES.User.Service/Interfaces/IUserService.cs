using FIAP.Hackaton.OES.User.Service.Dto.User;

namespace FIAP.Hackaton.OES.User.Service.Interfaces;
public interface IUserService
{
    ICollection<UserOutputDto> GetAll();
    UserOutputDto? GetById(long id);
    Task Create(UserCreateDto entity);
    void Update(UserUpdateDto entity);
    void DeleteById(long id);
    UserOutputDto GetByUserAndPassword(string user, string password);
}
