using PurrBank.BusinessRules.Commands.UserCommand;
using PurrBank.BusinessRules.EntitiesLogic.UserLogic.Contract;
using PurrBank.Entities;
using PurrBank.Tools;
using Tests.Helper;
using Xunit;

namespace EntitiesLogics.UnitTests;

public class UserLogicUnitTests
{

    public IUserLogic Logic { get; set; }
    private readonly string StandardFirstName;
    private readonly string StandardLastName;
    private readonly string StandardEmail;

    public UserLogicUnitTests()
    {
        StandardLastName = "some last name";
        StandardFirstName = "some first name";
        StandardEmail = "some@email.com";
        EnvironmentSetter.SetTestEnvToTrue();
        Logic = DIHandler.GetService<IUserLogic>();
    }

    [Fact]
    public void GivenCreateUserCommand_ShouldReturnValidUser()
    {
        //arrange
        var command = new CreateUserCommand() { Email = StandardEmail, FirstName = StandardFirstName, LastName = StandardLastName };

        //act
        var user = Logic.CreateEntity(command);

        //assert
        Assert.Equal(StandardFirstName, user.FirstName);
        Assert.Equal(StandardLastName, user.LastName);
        Assert.Equal(StandardEmail, user.Email);

    }

    [Fact]
    public void GivenUpdateUserCommand_ShouldReturnValidUser()
    {
        //arrange
        var newFirstName = "new first name";
        var newLastName = "new last name";
        var command = new UpdateUserCommand() { FirstName = newFirstName, LastName = newLastName };
        var user = new User(StandardFirstName, StandardLastName, StandardEmail);

        //act
        var updated = Logic.UpdateEntity(command, user);

        //assert
        Assert.Equal(newFirstName, user.FirstName);
        Assert.Equal(newLastName, user.LastName);
    }
}