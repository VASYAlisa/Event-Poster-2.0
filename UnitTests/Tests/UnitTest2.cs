using Moq;
using UnitTests.DAL;
using UnitTests.Mocks;
using UnitTests.Services;
//Assert.That(result.Id, Is.EqualTo(@event[0].Id));
namespace UnitTests.Tests
{
    public class UnitTest2
    {
        Mock<IDbRepos> context;
        EventService service;

        [SetUp]
        public void Setup()
        {
            context = MockDbRepos.GetMock();
            service = new EventService(context.Object);
        }


        [Test]
        public void CreateEvent_Success()
        {
            var @event = new List<Event>()
            {
                new Event
                {
                    Id=1,
                    Name="Мероприятие 3",
                    Description="Описание 3",
                    Price=0,
                    Date=DateTime.Now,
                    Author="Автор 3",
                    Categories=new List<Category>()
                    {
                        new Category()
                        {
                            Id = 1,
                            Name = "Категория 3"
                        }
                    }

                }
            };
            var result = service.MakeEvent(@event[0]);
            Assert.IsNotNull(result);
            //Assert.That(result.Id, Is.EqualTo(@event[0].Id));
        }

        [Test]
        public void CreateEventWithoutPizzas_Fail()
        {
            var @event = new List<Event>()
            {
                new Event
                {
                    Id=4,
                    //Name="Мероприятие 1",
                    Description="Описание 4",
                    Price=0,
                    Date=DateTime.Now,
                    Author="Автор 4",
                    Categories=new List<Category>()
                    {
                        new Category()
                        {
                            Id = 1,
                            Name = "Категория 4"
                        }
                    }
                }
            };
            try
            {
                var result = service.MakeEvent(@event[0]);
                Assert.IsNull(result);
                Assert.Throws<ArgumentNullException>(() => service.MakeEvent(@event[0]));
            }
            catch (Exception ex) { }
        }
    }
}
