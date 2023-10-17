using MongoDB.Driver;

namespace PurrBank.Context.Contracts
{
    public interface INoSqlContext : IDisposable
    {
        IMongoCollection<T> Set<T>();
    }
}
