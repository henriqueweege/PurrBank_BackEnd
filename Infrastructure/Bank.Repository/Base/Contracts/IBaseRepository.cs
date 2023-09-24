using Bank.Entities.Contracts;
using System.Linq.Expressions;

namespace Bank.Repository.Base.Contracts
{
    public interface IBaseRepository<E> where E : class, IEntity
    {
        public E? Save(E entity);
        public IQueryable<E> GetByFilter(Expression<Func<E, bool>> filter);
        public E? GetById(int id);
        public E? Update(E entity);
        public bool Delete(E entity);
    }
}
