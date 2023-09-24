using Bank.Entities.Contracts;

namespace Bank.BusinessRules.Commands.Contracts
{
    public interface IDeleteCommand<E> where E:class, IEntity
    {
        int Id { get; }
    }
}
