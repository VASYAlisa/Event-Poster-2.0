using Event_Poster_2._0.Model.Repositories.Data;
using Moq;
using UnitTests.DAL;

namespace UnitTests.Mocks
{
    public static class MockCategoryRepository
    {
        public static List<Category> categories = new List<Category>()
        {
             new Category()
                {
                    Id = 1,
                    Name = "Категория 1",
                    
                },

                new Category()
                {
                    Id = 2,
                    Name = "Категория 2",
                   
                }
        };
        public static Mock<IRepository<Category>> GetMock()
        {
            var mock = new Mock<IRepository<Category>>();

            mock.Setup(m => m.GetList()).Returns(() => categories);
            mock.Setup(m => m.GetItem(It.IsAny<int>()))
                .Returns((int id) => categories.First());
            mock.Setup(m => m.Create(It.IsAny<Category>()))
                .Callback(() => { return; });
            mock.Setup(m => m.Update(It.IsAny<Category>()))
               .Callback(() => { return; });
            mock.Setup(m => m.Delete(It.IsAny<int>()))
               .Callback(() => { return; });
            return mock;
        }
    }
}
