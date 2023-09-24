using Microsoft.EntityFrameworkCore;
using PurrBank.Context.Contracts;
using PurrBank.Entities;
using PurrBank.Tools;

namespace PurrBank.Context;

public class DataContext : DbContext, IDataContext
{
    public DataContext(DbContextOptionsBuilder dbContextOptionsBuilder) : base(dbContextOptionsBuilder.Options) { }


    protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
    {
        if (EnvironmentVerifier.IsTestEnv())
        {

            dbContextOptionsBuilder.UseInMemoryDatabase(databaseName: "inMemoryDb");
        }
        else
        {
            dbContextOptionsBuilder.UseMySql(AppSettings.ConnectionString.MySql, ServerVersion.AutoDetect(AppSettings.ConnectionString.MySql));
        }
    }
    public DbSet<User> User { get; set; }
}
