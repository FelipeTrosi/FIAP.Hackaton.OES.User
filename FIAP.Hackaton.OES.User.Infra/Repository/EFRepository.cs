using FIAP.Hackaton.OES.User.Domain.Entity.Abstracts;
using FIAP.Hackaton.OES.User.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Hackaton.OES.User.Infra.Repository
{
    public class EFRepository<T>(ApplicationDbContext context) : IRepository<T> where T : EntityBase
    {
        protected ApplicationDbContext _context = context;
        protected DbSet<T> _dbSet = context.Set<T>();

        public T Create(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public IList<T> GetAll() 
            => _dbSet.ToList();

        public T? GetById(long id)
            => _dbSet.FirstOrDefault(q => q.Id == id);

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void DeleteById(long id)
        {
            _dbSet.Remove(GetById(id)!);
            _context.SaveChanges();
        }
    }
}
