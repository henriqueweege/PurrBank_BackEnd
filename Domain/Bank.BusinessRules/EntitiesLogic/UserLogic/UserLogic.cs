﻿using Bank.BusinessRules.Commands.UserCommand;
using Bank.BusinessRules.EntitiesLogic.UserLogic.Contract;
using Bank.BusinessRules.Queries.UserQueries;
using Bank.Entities;
using System.Linq.Expressions;

namespace Bank.BusinessRules.EntitiesLogic.UserLogic
{
    public class UserLogic : IUserLogic
    {
        public User CreateEntity(CreateUserCommand command)
            => new User(command.FirstName, command.LastName, command.Email);

        public User UpdateEntity(UpdateUserCommand command, User entityToUpdate)
        {
            if (!string.IsNullOrWhiteSpace(command.FirstName))
            {
                entityToUpdate.ChangeFirstName(command.FirstName);
            }
            if (!string.IsNullOrWhiteSpace(command.LastName))
            {
                entityToUpdate.ChangeLastName(command.LastName);
            }

            return entityToUpdate;
        }

        public Expression<Func<User, bool>> GetFilter(User entity)
        {
            return (x =>
                        (entity.FirstName != null ? x.FirstName == entity.FirstName : true)
                        && (entity.LastName != null ? x.LastName == entity.LastName : true)
                        && (entity.Email != null ? x.Email == entity.Email : true)
                    );
        }

        public Expression<Func<User, bool>> GetFilter(GetUserByFilterQuery query) => GetFilter(new User(query.FirstName, query.LastName, query.Email));
    }
}
