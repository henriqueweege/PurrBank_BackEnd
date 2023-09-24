using MediatR;
using PurrBank.Entities.Contracts;

namespace PurrBank.BusinessRules.Commands
{
    public class CommandResult<E> : IRequest where E : class, IEntity
    {
        public E? Result { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public CommandResult()
        {

        }

        public CommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public CommandResult(bool success, string message, E entity)
        {
            Result = entity;
            Success = success;
            Message = message;
        }
    }

}
