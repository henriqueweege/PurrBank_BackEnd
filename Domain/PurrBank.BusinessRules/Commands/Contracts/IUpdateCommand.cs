using PurrBank.Entities.Contracts;

namespace PurrBank.BusinessRules.Commands.Contracts
{
    public interface IUpdateCommand<E> where E : class, IEntity
    {
        int Id { get; }
    }
}
