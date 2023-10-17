using MongoDB.Driver;
using PurrBank.Context.Contracts;
using PurrBank.Tools;
using System.ComponentModel;

namespace PurrBank.Context
{
    public class NoSqlContext : INoSqlContext
    {
        IMongoDatabase mongoDatabase = new MongoClient(
            MongoClientSettings
            .FromUrl(new MongoUrl(AppSettings.MongoSettings.ConnectionString)))
            .GetDatabase(AppSettings.MongoSettings.DatabaseName);

        public IMongoCollection<T> Set<T>()
        {
            return mongoDatabase.GetCollection<T>(((DescriptionAttribute[])typeof(T).GetCustomAttributes(typeof(DescriptionAttribute), false))[0].Description);
        }

        public void Dispose()
        {
            mongoDatabase = null;
        }
    }
}
