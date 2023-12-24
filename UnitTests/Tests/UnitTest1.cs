using Moq;
using System.Collections.ObjectModel;
using UnitTests.DAL;
using UnitTests.Mocks;
using UnitTests.Services;

namespace UnitTests.Tests
{
    public class UnitTest1
    {
        Mock<IDbRepos> context;
        UserService service;

        [SetUp]
        public void Setup()
        {
            context = MockDbRepos.GetMock();
            service = new UserService(context.Object);
        }


        [Test]
        public void ValidEntryData()
        {
            var users = new List<User>()
            {
                new User
                {
                    Password = "password",
                    UserName = "name",
                }
            };
            context.Setup(repo => repo.Users.GetList()).Returns(users);
            var result = service.Authenticate(users[0].UserName, users[0].Password);
            Assert.IsTrue(result);
        }

        [Test]
        public void InvalidEntryName()
        {
            var users = new List<User>()
            {
                new User
                {
                    Password = "password",
                    UserName = "name",
                }
            };
            context.Setup(repo => repo.Users.GetList()).Returns(users);
            var result = service.Authenticate("invalidUser", users[0].Password);
            Assert.IsFalse(result);
        }

        [Test]
        public void InvalidEntryPassword()
        {
            var users = new List<User>()
            {
                new User
                {
                    Password = "password",
                    UserName = "name",
                }
            };
            context.Setup(repo => repo.Users.GetList()).Returns(users);
            var result = service.Authenticate(users[0].UserName, "InvalidPassword");
            Assert.IsFalse(result);
        }
    }
}