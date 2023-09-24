using Bank.Context.Contracts;
using Bank.Entities;
using Bank.Repository.Base;
using Bank.Repository.Contracts;

namespace Bank.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IDataContext context) : base(context)
        {
        }
    }
}
