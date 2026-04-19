using FIAP.Hackaton.OES.User.Domain.Entity;
using FIAP.Hackaton.OES.User.Infra.Repository.Interfaces;

namespace FIAP.Hackaton.OES.User.Infra.Repository
{
    public class UserRepository : EFRepository<UserEntity>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public UserEntity? GetByEmail(string email)
            => _context.Users.FirstOrDefault(q => q.Email == email);
        
    }
}
