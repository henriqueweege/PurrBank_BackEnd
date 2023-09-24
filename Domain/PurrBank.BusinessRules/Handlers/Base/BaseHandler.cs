using PurrBank.BusinessRules.Commands;
using PurrBank.BusinessRules.Commands.Contracts;
using PurrBank.BusinessRules.EntitiesLogic.Contract;
using PurrBank.BusinessRules.Queries.Contracts;
using PurrBank.Entities.Contracts;

namespace PurrBank.BusinessRules.Handlers.Base;

public abstract class BaseHandler<E,
                      L,
                      CC,
                      UC,
                      DC,
                      GBFQ,
                      GBIQ> where E : class, IEntity
                            where CC : ICreateCommand<E>
                            where UC : IUpdateCommand<E>
                            where DC : IDeleteCommand<E>
                            where GBFQ : IGetByFilterQuery<E>
                            where GBIQ : IGetByIdQuery<E>
                            where L : class, ILogic<E, CC, UC, GBFQ>
{

    public abstract CommandResult<E> Handle(CC command);
    public abstract CommandResult<E> Handle(UC command);
}
