using Bank.BusinessRules.Commands.Contracts;
using Bank.Entities;
using MediatR;

namespace Bank.BusinessRules.Commands.UserCommand
{
    public class DeleteUserCommand : IDeleteCommand<User>, IRequest<CommandResult<User>>
    {
        public int Id { get; set; }
    }
}
