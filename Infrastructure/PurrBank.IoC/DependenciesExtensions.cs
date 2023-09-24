using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PurrBank.BusinessRules.Commands.UserCommand;
using PurrBank.BusinessRules.EntitiesLogic.Contract;
using PurrBank.BusinessRules.EntitiesLogic.UserLogic;
using PurrBank.BusinessRules.EntitiesLogic.UserLogic.Contract;
using PurrBank.BusinessRules.Queries.UserQueries;
using PurrBank.Context;
using PurrBank.Context.Contracts;
using PurrBank.Entities;
using PurrBank.IoC;
using PurrBank.Repository;
using PurrBank.Repository.Base.Contracts;
using PurrBank.Repository.Contracts;

namespace PurrBank.IoC;
public static class DependenciesExtensions
{
    public static void AddRepositories(this IServiceCollection services)
    {

        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IBaseRepository<User>, UserRepository>();
    }

    public static void AddEntitiesLogics(this IServiceCollection services)
    {
        services.AddTransient<IUserLogic, UserLogic>();
        services.AddTransient<ILogic<User, CreateUserCommand, UpdateUserCommand, GetUserByFilterQuery>, UserLogic>();
    }

    public static void AddDbContext(this IServiceCollection services)
    {
        services.AddDbContext<IDataContext, DataContext>();
        services.AddTransient<DbContextOptionsBuilder>();
    }

    public static void AddMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateUserCommand).Assembly));
    }
}
