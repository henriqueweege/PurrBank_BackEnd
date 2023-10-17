using MongoDB.Driver;
using PurrBank.Context.Contracts;
using PurrBank.Entities.Contracts;
using PurrBank.Repository.Base.Contracts;

namespace PurrBank.Repository.Base
{
    public class NoSqlRepository<E> : IDisposable, INoSqlRepository<E> where E : class, IEntity
    {
        private INoSqlContext _context { get; set; }

        public NoSqlRepository(INoSqlContext context)
        {
            _context = context;
        }

        public virtual async Task<IList<E>> GetByJsonFilter(FilterDefinition<E> filter = null)
        {
            var result = await _context.Set<E>().FindAsync(filter);
            return await result.ToListAsync();
        }

        public virtual async Task Add(E entity)
        {
            await _context.Set<E>().InsertOneAsync(entity);
        }

        public virtual async Task AddRange(IEnumerable<E> entities)
        {
            await _context.Set<E>().InsertManyAsync(entities);
        }

        public virtual async Task Update(FilterDefinition<E> filterDefinition, UpdateDefinition<E> updateDefinition)
        {
            await _context.Set<E>().UpdateOneAsync(filterDefinition, updateDefinition);
        }

        public virtual async Task UpdateRange(FilterDefinition<E> filterDefinition, UpdateDefinition<E> updateDefinition)
        {
            await _context.Set<E>().UpdateManyAsync(filterDefinition, updateDefinition);
        }

        public virtual async Task Remove(FilterDefinition<E> filterDefinition)
        {
            _context.Set<E>().DeleteOne(filterDefinition);
        }

        public virtual async Task RemoveRange(FilterDefinition<E> filterDefinition)
        {
            _context.Set<E>().DeleteMany(filterDefinition);
        }

        public virtual void Dispose()
        {
            _context.Dispose();
        }
    }
}
