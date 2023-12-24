using Event_Poster_2._0.Model.Repositories.Data;
using Moq;
using UnitTests.DAL;

namespace UnitTests.Mocks
{
    public static class MockCityRepository
    {
        public static List<City> cities = new List<City>()
        {
             new City()
                {
                    Id = 1,
                    Name = "Категория 1",

                },

                new City()
                {
                    Id = 2,
                    Name = "Категория 2",

                }
        };
        public static Mock<IRepository<City>> GetMock()
        {
            var mock = new Mock<IRepository<City>>();

            mock.Setup(m => m.GetList()).Returns(() => cities);
            mock.Setup(m => m.GetItem(It.IsAny<int>()))
                .Returns((int id) => cities.First());
            mock.Setup(m => m.Create(It.IsAny<City>()))
                .Callback(() => { return; });
            mock.Setup(m => m.Update(It.IsAny<City>()))
               .Callback(() => { return; });
            mock.Setup(m => m.Delete(It.IsAny<int>()))
               .Callback(() => { return; });
            return mock;
        }
    }
}
