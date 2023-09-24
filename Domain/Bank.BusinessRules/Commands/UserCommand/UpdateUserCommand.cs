using Bank.BusinessRules.Commands.Contracts;
using Bank.Entities;
using MediatR;

namespace Bank.BusinessRules.Commands.UserCommand
{
    public class UpdateUserCommand : IUpdateCommand<User>, IRequest<CommandResult<User>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
