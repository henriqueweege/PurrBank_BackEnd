using MediatR;
using PurrBank.BusinessRules.Commands.Contracts;
using PurrBank.Entities;

namespace PurrBank.BusinessRules.Commands.UserCommand
{
    public class UpdateUserCommand : IUpdateCommand<User>, IRequest<CommandResult<User>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
