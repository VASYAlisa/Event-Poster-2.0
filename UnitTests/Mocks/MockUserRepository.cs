using Event_Poster_2._0.Model.Repositories.Data;
using Moq;
using System.Collections.ObjectModel;
using UnitTests.DAL;

namespace UnitTests.Mocks
{
    public class MockUserRepository
    {
        public static List<User> users = new List<User>();

        public static Mock<IRepository<User>> GetMock()
        {
            var mock = new Mock<IRepository<User>>();
            mock.Setup(m => m.GetList()).Returns(() => users);
            mock.Setup(m => m.GetItem(It.IsAny<int>()))
                .Returns((int id) => users.FirstOrDefault(o => o.Id == id));
            mock.Setup(m => m.Create(It.IsAny<User>()))
                .Callback((User User) => {
                    users.Add(User);
                });
            mock.Setup(m => m.Update(It.IsAny<User>()))
               .Callback(() => { return; });
            mock.Setup(m => m.Delete(It.IsAny<int>()))
               .Callback(() => { return; });
            return mock;
        }
    }
}
