using PurrBank.Entities.Contracts;

namespace PurrBank.BusinessRules.Commands.Contracts
{
    public interface ICreateCommand<E> where E : class, IEntity
    {
    }
}
