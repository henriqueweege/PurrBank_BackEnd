using PurrBank.Entities.Contracts;

namespace PurrBank.BusinessRules.Queries.Contracts
{
    public interface IGetByIdQuery<E> where E : class, IEntity
    {
        int Id { get; }
    }
}
