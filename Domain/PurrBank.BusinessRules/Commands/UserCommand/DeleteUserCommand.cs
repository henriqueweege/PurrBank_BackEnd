using MediatR;
using PurrBank.BusinessRules.Commands.Contracts;
using PurrBank.Entities;

namespace PurrBank.BusinessRules.Commands.UserCommand
{
    public class DeleteUserCommand : IDeleteCommand<User>, IRequest<CommandResult<User>>
    {
        public int Id { get; set; }
    }
}
