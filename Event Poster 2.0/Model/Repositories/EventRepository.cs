using Event_Poster_2._0.Model.DAL;
using Event_Poster_2._0.Model.Data;
using Event_Poster_2._0.Model.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Poster_2._0.Model.Repositories
{
    public class EventRepository : IRepository<Event>

    {
        EventContext context;

        public EventRepository(EventContext _context) 
        {
            this.context = _context;
        }
        public void Create(Event item)
        {
            context.Events.Add(item);
        }

        public void Delete(int id)
        {
            Event @event = context.Events.Find(id);
            if (@event != null)
                context.Events.Remove(@event);
        }

        public Event GetItem(int id)
        {
            return context.Events.Include(i=>i.Categories).Where(p => p.Id == id).First();
        }

        public ObservableCollection<Event> GetList()
        {
            return new ObservableCollection<Event>(context.Events.Include(i => i.Categories).ToList());
        }

        public void Update(Event item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
