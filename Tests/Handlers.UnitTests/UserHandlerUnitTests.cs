using MediatR;
using PurrBank.BusinessRules.Commands.UserCommand;
using PurrBank.BusinessRules.Queries.UserQueries;
using PurrBank.Tools;
using Tests.Helper;
using Tests.Helper.Orderer;
using Xunit;

namespace Handlers.UnitTests;
[TestCaseOrderer(
        ordererTypeName: "Tests.Helper.Orderer.PriorityOrderer",
        ordererAssemblyName: "Tests.Helper")]
public class UserHandlerUnitTests : IDisposable
{
    private IMediator _mediator;
    private readonly string StandardFirstName;
    private readonly string StandardLastName;
    private readonly string StandardEmail;
    public UserHandlerUnitTests()
    {
        EnvironmentSetter.SetTestEnvToTrue();
        _mediator = DIHandler.GetService<IMediator>();
        StandardLastName = "some last name";
        StandardFirstName = "some first name";
        StandardEmail = "some@email.com";
    }

    [Fact, TestPriority(1)]
    public void GivenCreateCommand_ShoudlCreateUser()
    {
        //arrange
        var command = new CreateUserCommand() { FirstName = StandardFirstName, LastName = StandardLastName, Email = $"1{StandardEmail}" };

        //act
        var result = _mediator.Send(command);
        result.Wait();

        //assert
        Assert.True(result.Result.Success);
        Assert.True(result.Result.Result.Id > 0);
    }

    [Fact, TestPriority(2)]

    public void GivenUpdateCommand_ShoudlUpdateUser()
    {
        //arrange
        var createCommand = new CreateUserCommand() { FirstName = StandardFirstName, LastName = StandardLastName, Email = $"2{StandardEmail}" };
        var created = _mediator.Send(createCommand);
        created.Wait();
        var idCreated = created.Result.Result.Id;
        var newValue = "updated";

        var updateCommand = new UpdateUserCommand() { Id = idCreated, FirstName = newValue, LastName = newValue };

        //act
        var result = _mediator.Send(updateCommand);
        result.Wait();

        //assert
        Assert.True(result.Result.Success);
        Assert.Equal(idCreated, result.Result.Result.Id);
        Assert.Equal(newValue, result.Result.Result.FirstName);
        Assert.Equal(newValue, result.Result.Result.LastName);
    }

    [Fact, TestPriority(3)]

    public void GivenGetByIdQuery_ShoudlReturnUser()
    {
        //arrange
        var createCommand = new CreateUserCommand() { FirstName = StandardFirstName, LastName = StandardLastName, Email = $"3{StandardEmail}" };
        var created = _mediator.Send(createCommand);
        created.Wait();
        var idCreated = created.Result.Result.Id;

        var query = new GetUserByIdQuery() { Id = idCreated };

        //act
        var result = _mediator.Send(query);
        result.Wait();

        //assert
        Assert.True(result.Result.Success);
        Assert.Equal(idCreated, result.Result.Result.FirstOrDefault().Id);

    }

    [Fact, TestPriority(4)]

    public void GivenGetByFilterQuery_ShoudlReturnUser()
    {
        //arrange
        var createCommand = new CreateUserCommand() { FirstName = StandardFirstName, LastName = StandardLastName, Email = $"4{StandardEmail}" };
        var created = _mediator.Send(createCommand);
        created.Wait();
        var idCreated = created.Result.Result.Id;

        var query = new GetUserByFilterQuery() { Email = created.Result.Result.Email };

        //act
        var result = _mediator.Send(query);
        result.Wait();

        //assert
        Assert.True(result.Result.Success);
        Assert.Equal(idCreated, result.Result.Result.FirstOrDefault().Id);

    }

    [Fact, TestPriority(5)]

    public void GivenRemoveCommand_ShoudlRemoveUser()
    {
        //arrange
        var createCommand = new CreateUserCommand() { FirstName = StandardFirstName, LastName = StandardLastName, Email = $"5{StandardEmail}" };
        var created = _mediator.Send(createCommand);
        created.Wait();
        var idCreated = created.Result.Result.Id;

        var removeCommand = new DeleteUserCommand() { Id = idCreated };

        //act
        var result = _mediator.Send(removeCommand);
        result.Wait();

        //assert
        Assert.True(result.Result.Success);

    }

    public void Dispose()
    {
        EnvironmentSetter.SetTestEnvToNull();
    }
}