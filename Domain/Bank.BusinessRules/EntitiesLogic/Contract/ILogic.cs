using Bank.BusinessRules.Commands.Contracts;
using Bank.BusinessRules.Queries.Contracts;
using Bank.Entities.Contracts;
using System.Linq.Expressions;

namespace Bank.BusinessRules.EntitiesLogic.Contract
{
    public interface ILogic<E, CC, UC, GBFQ> 
                                        where E : class, IEntity
                                        where CC : ICreateCommand<E>
                                        where UC: IUpdateCommand<E>
                                        where GBFQ: IGetByFilterQuery<E>
    {
        public E CreateEntity(CC command);
        public E UpdateEntity(UC command, E entityToUpdate);
        public Expression<Func<E, bool>> GetFilter(E entity);
        public Expression<Func<E, bool>> GetFilter(GBFQ query);
    }
}
