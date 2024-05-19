using Planets.Domain.Entities;
using FluentValidation;

namespace Planets.Domain.Interfaces
{
    public interface IBaseService<T> where T : BaseEntity
    {
        void Create<Validator>(T entity) where Validator : AbstractValidator<T>;
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        void Update<Validator>(T entity) where Validator : AbstractValidator<T>;

        void Delete(Guid id);
    }
}