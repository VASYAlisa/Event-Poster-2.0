using Event_Poster_2._0.Model.Repositories.Data;
using Moq;
using UnitTests.DAL;

namespace UnitTests.Mocks
{
    public static class MockEventRepository
    {
        public static List<Event> events = new List<Event>()
        {
             new Event()
                {
                    Id = 1,
                    Name = "Событие 1",
                    Price = 300,
                    Date= DateTime.Now,
                    Description="Описание 1",
                    //CityId= 1,
                    Categories = new List<Category>()
                    {
                        new Category()
                        {
                            Id = 1,
                            Name = "Категория 1"
                        }
                    }
                },

                new Event()
                {
                    Id = 2,
                    Name = "Событие 2",
                    Price = 345,
                    Date= DateTime.Now,
                    Description="Описание 2",
                    //CityId= 1,
                                        
                    Categories = new List<Category>()
                    {
                        new Category()
                        {
                            Id = 2,
                            Name = "Категория 2"
                        }
                    }
                }
        };
        public static Mock<IRepository<Event>> GetMock()
        {
            var mock = new Mock<IRepository<Event>>();

            mock.Setup(m => m.GetList()).Returns(() => events);
            mock.Setup(m => m.GetItem(It.IsAny<int>()))
                .Returns((int id) => events.First());
            mock.Setup(m => m.Create(It.IsAny<Event>()))
                .Callback(() => { return; });
            mock.Setup(m => m.Update(It.IsAny<Event>()))
               .Callback(() => { return; });
            mock.Setup(m => m.Delete(It.IsAny<int>()))
               .Callback(() => { return; });
            return mock;
        }
    }
}
