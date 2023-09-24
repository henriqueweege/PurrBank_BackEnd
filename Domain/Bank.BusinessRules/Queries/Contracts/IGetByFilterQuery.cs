using Bank.Entities.Contracts;

namespace Bank.BusinessRules.Queries.Contracts
{
    public interface IGetByFilterQuery<E> where E : class, IEntity
    {
    }
}
