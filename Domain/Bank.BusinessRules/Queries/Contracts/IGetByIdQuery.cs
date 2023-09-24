using Bank.Entities.Contracts;

namespace Bank.BusinessRules.Queries.Contracts
{
    public interface IGetByIdQuery<E> where E : class,IEntity
    {
        int Id { get; }
    }
}
