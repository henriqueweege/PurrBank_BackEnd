using PurrBank.Entities.Contracts;

namespace PurrBank.BusinessRules.Queries.Contracts
{
    public interface IGetByFilterQuery<E> where E : class, IEntity
    {
    }
}
