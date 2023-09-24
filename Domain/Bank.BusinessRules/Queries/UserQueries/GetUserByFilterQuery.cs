using Bank.BusinessRules.Queries.Contracts;
using Bank.Entities;
using MediatR;

namespace Bank.BusinessRules.Queries.UserQueries
{
    public class GetUserByFilterQuery : IGetByFilterQuery<User>, IRequest<QueryResult<User>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
