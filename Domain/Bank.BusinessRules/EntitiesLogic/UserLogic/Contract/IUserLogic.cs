using Bank.BusinessRules.Commands.UserCommand;
using Bank.BusinessRules.EntitiesLogic.Contract;
using Bank.BusinessRules.Queries.UserQueries;
using Bank.Entities;

namespace Bank.BusinessRules.EntitiesLogic.UserLogic.Contract
{
    public interface IUserLogic : ILogic<User, CreateUserCommand, UpdateUserCommand, GetUserByFilterQuery>
    {
    }
}
