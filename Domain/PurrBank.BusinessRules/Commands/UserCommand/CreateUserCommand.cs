using MediatR;
using PurrBank.BusinessRules.Commands.Contracts;
using PurrBank.Entities;

namespace PurrBank.BusinessRules.Commands.UserCommand
{
    public class CreateUserCommand : ICreateCommand<User>, IRequest<CommandResult<User>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
