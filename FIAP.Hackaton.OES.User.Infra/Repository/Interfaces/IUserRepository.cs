using FIAP.Hackaton.OES.User.Domain.Entity;

namespace FIAP.Hackaton.OES.User.Infra.Repository.Interfaces;

public interface IUserRepository : IRepository<UserEntity>
{
    UserEntity? GetByEmail(string email);
}
