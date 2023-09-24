using PurrBank.BusinessRules.Commands;
using PurrBank.BusinessRules.Commands.Contracts;
using PurrBank.BusinessRules.EntitiesLogic.Contract;
using PurrBank.BusinessRules.Enums;
using PurrBank.BusinessRules.Enums.Extensions;
using PurrBank.BusinessRules.Queries;
using PurrBank.BusinessRules.Queries.Contracts;
using PurrBank.Entities.Contracts;
using PurrBank.Repository.Base.Contracts;

namespace PurrBank.BusinessRules.Handlers.Base
{
    public class CRUDHandler<E, C, CC, UC, DC, GBFQ, GBIQ>
              : BaseHandler<E, C, CC, UC, DC, GBFQ, GBIQ>
              where E : class, IEntity
              where C : class, ILogic<E, CC, UC, GBFQ>
              where CC : ICreateCommand<E>
              where UC : IUpdateCommand<E>
              where DC : IDeleteCommand<E>
              where GBFQ : IGetByFilterQuery<E>
              where GBIQ : IGetByIdQuery<E>
    {
        private static ILogic<E, CC, UC, GBFQ> Logic { get; set; }
        private static IBaseRepository<E> Repository { get; set; }
        public CRUDHandler(ILogic<E, CC, UC, GBFQ> converter, IBaseRepository<E> repository)
        {
            Logic = converter;
            Repository = repository;
        }

        public override CommandResult<E> Handle(CC command)
        {
            try
            {
                var entity = Logic.CreateEntity(command);
                var resultCreate = Repository.Save(entity);

                if (resultCreate is null)
                {
                    return new CommandResult<E>(false, EErrorMessages.INTERNAL_SERVER_ERROR.GetDescription(), entity);
                }
                return new CommandResult<E>(true, ESuccessMessages.OK_REQUISITON_COMPLETED_SUCCESSFULLY.GetDescription(), entity);
            }
            catch (ArgumentException ex)
            {
                return new CommandResult<E>(false, $"BadRequest: {ex.Message}");
            }
            catch (Exception ex)
            {
                return new CommandResult<E>(false, ex.InnerException.Message);
            }

        }

        public override CommandResult<E> Handle(UC command)
        {
            try
            {
                var entityToUpdate = Repository.GetById(command.Id);

                if (entityToUpdate is null)
                {
                    return new CommandResult<E>(false, EErrorMessages.BAD_REQUEST.GetDescription());
                }

                entityToUpdate = Logic.UpdateEntity(command, entityToUpdate);
                var resultCreate = Repository.Update(entityToUpdate);

                if (resultCreate is not null)
                {
                    return new CommandResult<E>(true, ESuccessMessages.OK_REQUISITON_COMPLETED_SUCCESSFULLY.GetDescription(), entityToUpdate);
                }
                return new CommandResult<E>(false, EErrorMessages.INTERNAL_SERVER_ERROR.GetDescription(), entityToUpdate);
            }
            catch (ArgumentException ex)
            {
                return new CommandResult<E>(false, $"BadRequest: {ex.Message}");
            }
            catch (Exception ex)
            {
                return new CommandResult<E>(false, ex.InnerException.Message);
            }

        }

        public CommandResult<E> Handle(DC command)
        {
            try
            {
                var entityToDelete = Repository.GetById(command.Id);

                if (entityToDelete is null)
                {
                    return new CommandResult<E>(true, EErrorMessages.BAD_REQUEST.GetDescription());
                }

                var deleted = Repository.Delete(entityToDelete);

                if (deleted)
                {
                    return new CommandResult<E>(true, ESuccessMessages.NO_CONTENT_REQUISITON_COMPLETED_SUCCESSFULLY.GetDescription());
                }
                return new CommandResult<E>(false, EErrorMessages.INTERNAL_SERVER_ERROR.GetDescription());

            }
            catch (Exception ex)
            {
                return new CommandResult<E>(false, ex.InnerException.Message);
            }
        }

        public QueryResult<E> Handle(GBFQ query)
        {
            try
            {
                var filter = Logic.GetFilter(query);
                var entities = Repository.GetByFilter(filter);

                if (entities != null && entities.Count() > 0)
                {
                    return new QueryResult<E>(true, ESuccessMessages.OK_REQUISITON_COMPLETED_SUCCESSFULLY.GetDescription(), entities);
                }
                else
                {
                    return new QueryResult<E>(true, ESuccessMessages.NO_CONTENT_REQUISITON_COMPLETED_SUCCESSFULLY.GetDescription(), entities);
                }
            }
            catch (Exception ex)

            {
                return new QueryResult<E>(false, ex.InnerException.Message);
            }
        }

        public QueryResult<E> Handle(GBIQ query)
        {
            try
            {
                var entities = Repository.GetById(query.Id);
                if (entities != null)
                {
                    return new QueryResult<E>(true, ESuccessMessages.OK_REQUISITON_COMPLETED_SUCCESSFULLY.GetDescription(), entities);
                }
                else
                {
                    return new QueryResult<E>(true, ESuccessMessages.NO_CONTENT_REQUISITON_COMPLETED_SUCCESSFULLY.GetDescription(), entities);
                }
            }
            catch (Exception ex)
            {
                return new QueryResult<E>(false, ex.InnerException.Message);
            }
        }
    }
}
