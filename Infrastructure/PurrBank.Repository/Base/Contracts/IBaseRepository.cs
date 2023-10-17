using PurrBank.Entities.Contracts;
using System.Linq.Expressions;

namespace PurrBank.Repository.Base.Contracts
{
    public interface IBaseRepository<E> where E : class, IEntity
    {
        public Task<E?> Save(E entity);
        public Task<IQueryable<E>> GetByFilter(Expression<Func<E, bool>> filter);
        public Task<E?> GetById(int id);
        public Task<E?> Update(E entity);
        public Task<bool> Delete(E entity);
    }
}
