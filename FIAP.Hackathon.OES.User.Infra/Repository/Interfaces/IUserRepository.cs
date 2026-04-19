using FIAP.Hackathon.OES.User.Domain.Entity;

namespace FIAP.Hackathon.OES.User.Infra.Repository.Interfaces;

public interface IUserRepository : IRepository<UserEntity>
{
    UserEntity? GetByEmail(string email);
}
