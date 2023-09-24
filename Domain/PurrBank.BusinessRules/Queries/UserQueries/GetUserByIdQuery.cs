using MediatR;
using PurrBank.BusinessRules.Queries.Contracts;
using PurrBank.Entities;

namespace PurrBank.BusinessRules.Queries.UserQueries
{
    public class GetUserByIdQuery : IGetByIdQuery<User>, IRequest<QueryResult<User>>
    {
        public int Id { get; set; }
    }
}
