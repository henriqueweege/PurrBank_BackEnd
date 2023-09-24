using PurrBank.Entities.Contracts;

namespace PurrBank.BusinessRules.Commands.Contracts
{
    public interface IDeleteCommand<E> where E : class, IEntity
    {
        int Id { get; }
    }
}
