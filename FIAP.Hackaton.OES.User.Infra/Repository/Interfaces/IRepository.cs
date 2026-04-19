using FIAP.Hackaton.OES.User.Domain.Entity.Abstracts;

namespace FIAP.Hackaton.OES.User.Infra.Repository.Interfaces;

public interface IRepository<T> where T : EntityBase
{
    IList<T> GetAll();
    T? GetById(long id);
    T Create(T entity);
    void Update(T entity);
    void DeleteById(long id);

}
