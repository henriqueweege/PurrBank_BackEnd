using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace PurrBank.Context.Contracts
{
    public interface IDataContext : IDisposable
    {
        EntityEntry Entry(object entity);
        DbSet<E> Set<E>() where E : class;
        int SaveChanges();
    }
}
