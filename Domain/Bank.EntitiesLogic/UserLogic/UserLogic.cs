using Bank.Entities;
using Bank.EntitiesLogic.UserLogic.Contract;
using System.Linq.Expressions;

namespace Bank.EntitiesLogic.UserLogic
{
    public class UserLogic : IUserLogic
    {
        public Expression<Func<User, bool>> GetFilter(User entity)
        {
            return (x =>
                        (entity.FirstName != null ? x.FirstName == entity.FirstName : true)
                        && (entity.LastName != null ? x.LastName == entity.LastName : true)
                        && (entity.Email != null ? x.Email == entity.Email : true)
                    );
        }
    }
}
