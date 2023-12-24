
using Event_Poster_2._0.Model.DAL;

namespace Event_Poster_2._0.Model.Repositories.Data
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
        IRepository<ParticipationEvent> ParticipationEvents { get; }
        int Save();
    }
}
