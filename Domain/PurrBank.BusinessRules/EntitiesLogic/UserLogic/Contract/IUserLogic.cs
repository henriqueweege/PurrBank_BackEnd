using PurrBank.BusinessRules.Commands.UserCommand;
using PurrBank.BusinessRules.EntitiesLogic.Contract;
using PurrBank.BusinessRules.Queries.UserQueries;
using PurrBank.Entities;

namespace PurrBank.BusinessRules.EntitiesLogic.UserLogic.Contract
{
    public interface IUserLogic : ILogic<User, CreateUserCommand, UpdateUserCommand, GetUserByFilterQuery>
    {
    }
}
