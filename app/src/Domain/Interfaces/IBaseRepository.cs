using Planets.Domain.Entities;

namespace Planets.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Create(T entity);
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        void Update(T entity);

        void Delete(Guid id);
    }
}