using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace PurrBank.Context.Contracts
{
    public interface ISqlContext : IDisposable
    {
        EntityEntry Entry(object entity);
        DbSet<E> Set<E>() where E : class;
        int SaveChanges();
    }
}
