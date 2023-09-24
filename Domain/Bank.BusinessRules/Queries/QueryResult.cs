using Bank.Entities.Contracts;
using MediatR;

namespace Bank.BusinessRules.Queries
{
    public class QueryResult<E> : IRequest where E : class, IEntity
    {
        public IEnumerable<E>? Result { get; private set; }
        public bool Success { get; private set; }
        public string Message { get; private set; }



        public QueryResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
        public QueryResult(bool success, string message, E entity)
        {
            Success = success;
            Message = message;
            Result = new List<E>() { entity };
        }
        public QueryResult(bool success, string message, IEnumerable<E> entity)
        {
            Success = success;
            Message = message;
            Result = entity;
        }
    }
}
