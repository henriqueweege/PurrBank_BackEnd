using MongoDB.Driver;
using PurrBank.Entities.Contracts;

namespace PurrBank.Repository.Base.Contracts
{
    public interface INoSqlRepository<E> where E : class, IEntity
    {
        Task<IList<E>> GetByJsonFilter(FilterDefinition<E> filter = null);
        Task Add(E entity);
        Task AddRange(IEnumerable<E> entities);
        Task Update(FilterDefinition<E> filterDefinition, UpdateDefinition<E> updateDefinition);
        Task UpdateRange(FilterDefinition<E> filterDefinition, UpdateDefinition<E> updateDefinition);
        Task Remove(FilterDefinition<E> filterDefinition);
        Task RemoveRange(FilterDefinition<E> filterDefinition);
    }
}