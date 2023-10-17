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
using System.ComponentModel.DataAnnotations;

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

        public async Task<CommandResult<User>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            => await Handle(request);


        public async Task<CommandResult<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if(!new EmailAddressAttribute().IsValid(request.Email))
            {
                return new CommandResult<User>(false, EErrorMessages.BAD_REQUEST_INVALID_EMAIL.GetDescription());
            }

            var exists = await Handle(new GetUserByFilterQuery() { Email = request.Email });
            if (exists.Result.Any())
            {
                return new CommandResult<User>(false, ESuccessMessages.EMAIL_ALREADY_REGISTERED.GetDescription());
            }
            return await Handle(request);
        }

        public async Task<CommandResult<User>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            => await Handle(request);

        public async Task<QueryResult<User>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            => await Handle(request);

        public async Task<QueryResult<User>> Handle(GetUserByFilterQuery request, CancellationToken cancellationToken)
            => await Handle(request);
    }
}
