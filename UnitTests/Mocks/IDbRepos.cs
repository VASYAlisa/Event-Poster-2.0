using UnitTests.DAL;
using Event_Poster_2._0.Model.Repositories.Data;


namespace UnitTests.Mocks
{
    public interface IDbRepos
    {
        IRepository<Event> Events { get; }
        IRepository<Category> Categories { get; }
        IRepository<City> Cities { get; }
        IRepository<Participation> Participations { get; }
        IRepository<Participant> Participants { get; }
        IRepository<Status> Statuses { get; }
        IRepository<User> Users { get; }
        IRepository<UserType> UserTypes { get; }
        int Save();
    }
}
