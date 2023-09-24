using Bank.Entities.Contracts;

namespace Bank.BusinessRules.Commands.Contracts
{
    public interface ICreateCommand<E> where E : class, IEntity
    {
    }
}
