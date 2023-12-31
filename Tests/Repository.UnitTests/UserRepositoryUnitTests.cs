﻿using PurrBank.BusinessRules.EntitiesLogic.UserLogic.Contract;
using PurrBank.Entities;
using PurrBank.Repository.Contracts;
using PurrBank.Tools;
using Tests.Helper;

namespace Repository.UnitTests
{
    public class UserRepositoryUnitTests
    {
        private readonly string StandardFirstName;
        private readonly string StandardLastName;
        private readonly string StandardEmail;
        private IUserRepository Repo { get; set; }
        private IUserLogic Logic { get; set; }
        public UserRepositoryUnitTests()
        {
            StandardLastName = "some last name";
            StandardFirstName = "some first name";
            StandardEmail = "some@email.com";
            EnvironmentSetter.SetTestEnvToTrue();
            Repo = DIHandler.GetService<IUserRepository>();
            Logic = DIHandler.GetService<IUserLogic>();
        }

        [Fact]
        public void GivenValidUser_ShouldSave()
        {
            //arrange
            var userToSave = new User(StandardFirstName, StandardLastName, StandardEmail);

            //act
            var userSaved = Repo.Save(userToSave).Result;

            //assert
            Assert.True(userSaved.Id > 0);
            Assert.NotNull(userSaved.FirstName);
            Assert.NotNull(userSaved.LastName);
            Assert.NotNull(userSaved.Email);

        }

        [Fact]
        public void GivenValidId_ShouldReturnUser()
        {
            //arrange
            var userToSave = new User(StandardFirstName, StandardLastName, StandardEmail);
            var userSaved = Repo.Save(userToSave).Result;

            //act
            var retrieved = Repo.GetById(userSaved.Id).Result;

            //assert
            Assert.Equal(userSaved.Id, retrieved.Id);
            Assert.Equal(userSaved.FirstName, retrieved.FirstName);
            Assert.Equal(userSaved.LastName, retrieved.LastName);
            Assert.Equal(userSaved.Email, retrieved.Email);

        }

        [Fact]
        public void GivenValidUser_ShouldDelete()
        {
            //arrange
            var userToSave = new User(StandardFirstName, StandardLastName, StandardEmail);
            var userSaved = Repo.Save(userToSave).Result;

            //act
            var userDeleted = Repo.Delete(userSaved).Result;

            //assert
            Assert.True(userDeleted);
            Assert.Null(Repo.GetByFilter(Logic.GetFilter(new User(null, null, null))).Result.Where(x => x.Id == userSaved.Id).FirstOrDefault());

        }

        [Fact]
        public void GivenValidUser_ShouldUpdate()
        {
            //arrange
            var userToSave = new User(StandardFirstName, StandardLastName, StandardEmail);
            var userSaved = Repo.Save(userToSave).Result;
            var newName = "newName";

            //act
            userSaved.ChangeFirstName(newName);
            var userUpdated = Repo.Update(userToSave).Result;

            //assert
            Assert.True(userUpdated.FirstName == newName);
            Assert.True(userUpdated.Id > 0);

        }

        [Fact]
        public void GivenValidFilter_ShouldReturnOneUser()
        {
            //arrange
            var anotherEmail = "another@mail.com";
            var userToSave1 = new User(StandardFirstName, StandardLastName, StandardEmail);
            var userSaved1 = Repo.Save(userToSave1).Result;
            var userToSave2 = new User(StandardFirstName, StandardLastName, "another@mail.com");
            var userSaved2 = Repo.Save(userToSave2).Result;



            //act
            var filter = Logic.GetFilter(new User(null, null, anotherEmail));
            var returnOfFunciton = Repo.GetByFilter(filter).Result.ToList();

            //assert
            Assert.Equal(userSaved2.Id, returnOfFunciton.FirstOrDefault().Id);
            Assert.True(returnOfFunciton.Count() == 1);
        }
    }
}
