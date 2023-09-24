using Microsoft.EntityFrameworkCore;
using PurrBank.Context;
using PurrBank.Context.Contracts;
using PurrBank.Entities.Contracts;
using PurrBank.Repository.Base.Contracts;
using System.Linq.Expressions;

namespace PurrBank.Repository.Base
{
    public class BaseRepository<E> : IDisposable, IBaseRepository<E> where E : class, IEntity
    {
        private DataContext Context { get; set; }
        private DbSet<E> EntitySet { get; set; }
        public BaseRepository(IDataContext context)
        {
            Context = (DataContext)context;
            EntitySet = Context.Set<E>();
        }

        public IQueryable<E> GetByFilter(Expression<Func<E, bool>> filter) => EntitySet.Where(filter);
        public E? GetById(int id) => EntitySet.FirstOrDefault(x => x.Id == id);

        public E? Save(E model)
        {
            Context.Add(model);
            if (Saved())
            {
                return model;
            }
            return null;
        }
        public E? Update(E model)
        {
            Context.Update(model);
            if (Saved())
            {
                return model;
            }
            return null;
        }
        public bool Delete(E model)
        {
            Context.Remove(model);
            return SaveChanges().Result > 0;
        }

        private bool Saved()
            => SaveChanges().Result > 0;


        public Task<int> SaveChanges() => Context.SaveChangesAsync();

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
