using Bank.BusinessRules.Commands.Contracts;
using Bank.Entities;
using MediatR;

namespace Bank.BusinessRules.Commands.UserCommand
{
    public class CreateUserCommand : ICreateCommand<User>, IRequest<CommandResult<User>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
