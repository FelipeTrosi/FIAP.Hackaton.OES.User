using FIAP.Hackathon.OES.User.Domain.Entity;
using FIAP.Hackathon.OES.User.Infra.Repository.Interfaces;

namespace FIAP.Hackathon.OES.User.Infra.Repository
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
