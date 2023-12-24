using Moq;


namespace UnitTests.Mocks
{
    public static class MockDbRepos
    {
        public static Mock<IDbRepos> GetMock()
        {
            var mock = new Mock<IDbRepos>();
            var eventMock = MockEventRepository.GetMock();
            var categoryMock = MockCategoryRepository.GetMock();
            //var statusMock = MockStatusRepository.GetMock();
            var cityMock = MockCityRepository.GetMock();
            var userMock = MockUserRepository.GetMock();

            mock.Setup(m => m.Events).Returns(() => eventMock.Object);
            mock.Setup(m => m.Categories).Returns(() => categoryMock.Object);
            mock.Setup(m => m.Cities).Returns(() => cityMock.Object);
            //mock.Setup(m => m.Orders).Returns(() => orderMock.Object);
            mock.Setup(m => m.Users).Returns(() => userMock.Object);
            // не тестируем запись в бд
            mock.Setup(m => m.Save()).Returns(() => { return 1; });
            return mock;
        }
    }
}
