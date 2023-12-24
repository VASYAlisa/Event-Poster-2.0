using System.Windows.Controls;
using UnitTests.DAL;
using UnitTests.Mocks;

namespace UnitTests.Services
{
    public class EventService
    {
        private IDbRepos context;
        public EventService(IDbRepos repos)
        {
            context = repos;
        }


        public Event MakeEvent(Event @event)
        {
            if (@event.Name == null) throw new ArgumentNullException("Событие не создано");
            var newEvent = new Event
            {
                Id = @event.Id,
                Date = DateTime.Now,
                Description = @event.Description,
                Name = @event.Name,
                Price= @event.Price,
                //StatusId= @event.StatusId,
                //CityId= @event.CityId,
                Categories= @event.Categories,
            };
            context.Events.Create(newEvent);
            if (context.Save() > 0)
            {
                var @event1 = GetEvent(@event.Id);
                return @event1;
            }

            return null;

        }

        public List<Event> GetAllEvents()
        {
            return context.Events.GetList().ToList();
        }
        public Event GetEvent(int Id)
        {
            return context.Events.GetItem(Id);
        }
        public void DeleteEvent(int id)
        {
            if (context.Events.GetItem(id) != null)
            {
                context.Events.Delete(id);
                context.Save();
            }
        }
    }
}
