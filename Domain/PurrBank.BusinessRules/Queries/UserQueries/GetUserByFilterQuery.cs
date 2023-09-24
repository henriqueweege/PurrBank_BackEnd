using MediatR;
using PurrBank.BusinessRules.Queries.Contracts;
using PurrBank.Entities;

namespace PurrBank.BusinessRules.Queries.UserQueries
{
    public class GetUserByFilterQuery : IGetByFilterQuery<User>, IRequest<QueryResult<User>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
