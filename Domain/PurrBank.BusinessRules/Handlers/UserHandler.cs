using MediatR;
using PurrBank.BusinessRules.Commands;
using PurrBank.BusinessRules.Commands.UserCommand;
using PurrBank.BusinessRules.EntitiesLogic.Contract;
using PurrBank.BusinessRules.EntitiesLogic.UserLogic;
using PurrBank.BusinessRules.Enums;
using PurrBank.BusinessRules.Enums.Extensions;
using PurrBank.BusinessRules.Handlers.Base;
using PurrBank.BusinessRules.Queries;
using PurrBank.BusinessRules.Queries.UserQueries;
using PurrBank.Entities;
using PurrBank.Repository.Base.Contracts;

namespace PurrBank.BusinessRules.Handlers
{
    public class UserHandler : CRUDHandler<User, UserLogic, CreateUserCommand, UpdateUserCommand, DeleteUserCommand, GetUserByFilterQuery, GetUserByIdQuery>,
                               IRequestHandler<UpdateUserCommand, CommandResult<User>>,
                               IRequestHandler<CreateUserCommand, CommandResult<User>>,
                               IRequestHandler<DeleteUserCommand, CommandResult<User>>,
                               IRequestHandler<GetUserByIdQuery, QueryResult<User>>,
                               IRequestHandler<GetUserByFilterQuery, QueryResult<User>>
    {
        public UserHandler(ILogic<User, CreateUserCommand, UpdateUserCommand, GetUserByFilterQuery> logic, IBaseRepository<User> repository) : base(logic, repository)
        {
        }

        public Task<CommandResult<User>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            => Task.FromResult(Handle(request));


        public Task<CommandResult<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var exists = Handle(new GetUserByFilterQuery() { Email = request.Email });
            if (exists.Result.Any())
            {
                return Task.FromResult(new CommandResult<User>(false, EErrorMessages.BAD_REQUEST_EMAIL_USED.GetDescription()));
            }
            return Task.FromResult(Handle(request));
        }

        public Task<CommandResult<User>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            => Task.FromResult(Handle(request));

        public Task<QueryResult<User>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            => Task.FromResult(Handle(request));

        public Task<QueryResult<User>> Handle(GetUserByFilterQuery request, CancellationToken cancellationToken)
            => Task.FromResult(Handle(request));
    }
}
