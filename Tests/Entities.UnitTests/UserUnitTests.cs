using PurrBank.Entities;

namespace Entities.UnitTests;

public class UserUnitTests
{
    private readonly string StandardFirstName;
    private readonly string StandardLastName;
    private readonly string StandardEmail;
    public UserUnitTests()
    {
        StandardLastName = "some last name";
        StandardFirstName = "some first name";
        StandardEmail = "some@email.com";
    }

    [Fact]
    public void GivenAUser_ChangeEmail_ShouldChangeEmail()
    {
        //arrange
        var user = new User(StandardFirstName, StandardLastName, StandardEmail);
        var newEmail = "new@email.com";

        //act
        user.ChangeEmail(newEmail);

        //assert
        Assert.Equal(newEmail, user.Email);
    }

    [Fact]
    public void GivenAUser_ChangeFirstName_ShouldChangeFirstName()
    {
        //arrange
        var user = new User(StandardFirstName, StandardLastName, StandardEmail);
        var newFirstName = "new first name";

        //act
        user.ChangeFirstName(newFirstName);

        //assert
        Assert.Equal(newFirstName, user.FirstName);
    }

    [Fact]
    public void GivenAUser_ChangeLastName_ShouldChangeLastName()
    {
        //arrange
        var user = new User(StandardFirstName, StandardLastName, StandardEmail);
        var newLastName = "new Last name";

        //act
        user.ChangeLastName(newLastName);

        //assert
        Assert.Equal(newLastName, user.LastName);
    }
}