using Bank.BusinessRules.Commands.UserCommand;
using Bank.BusinessRules.EntitiesLogic.Contract;
using Bank.BusinessRules.EntitiesLogic.UserLogic;
using Bank.BusinessRules.EntitiesLogic.UserLogic.Contract;
using Bank.BusinessRules.Queries.UserQueries;
using Bank.Context;
using Bank.Context.Contracts;
using Bank.Entities;
using Bank.Repository;
using Bank.Repository.Base.Contracts;
using Bank.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Bank.IoC;
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
