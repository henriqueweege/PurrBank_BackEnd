using Bank.Entities.Contracts;
using System.Linq.Expressions;

namespace Bank.EntitiesLogic.Contract
{
    public interface ILogic<E> where E : class, IEntity
    {
        E CreateEntity<CC>(CC command) where CC : ICreateCommand;
        public Expression<Func<E, bool>> GetFilter(E entity);
    }
}
