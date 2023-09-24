using Bank.Context.Contracts;
using Bank.Entities;
using Bank.Tools;
using Microsoft.EntityFrameworkCore;

namespace Bank.Context;

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
