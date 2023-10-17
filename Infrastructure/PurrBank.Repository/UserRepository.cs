using PurrBank.Context.Contracts;
using PurrBank.Entities;
using PurrBank.Repository.Base;
using PurrBank.Repository.Contracts;

namespace PurrBank.Repository
{
    public class UserRepository : SqlRepository<User>, IUserRepository
    {
        public UserRepository(IDataContext context) : base(context)
        {
        }
    }
}
