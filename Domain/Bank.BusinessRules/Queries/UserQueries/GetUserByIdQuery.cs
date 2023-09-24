using Bank.BusinessRules.Queries.Contracts;
using Bank.Entities;
using MediatR;

namespace Bank.BusinessRules.Queries.UserQueries
{
    public class GetUserByIdQuery : IGetByIdQuery<User>, IRequest<QueryResult<User>>
    {
        public int Id { get; set; }
    }
}
