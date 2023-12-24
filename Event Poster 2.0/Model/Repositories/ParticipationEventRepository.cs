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
    public class ParticipationEventRepository : IRepository<ParticipationEvent>
    {

        EventContext context;

        public ParticipationEventRepository(EventContext _context)
        {
            this.context = _context;
        }
        public void Create(ParticipationEvent item)
        {
            context.ParticipationEvents.Add(item);
        }

        public void Delete(int id)
        {
            ParticipationEvent @event = context.ParticipationEvents.Find(id);
            if (@event != null)
                context.ParticipationEvents.Remove(@event);
        }

        public ParticipationEvent GetItem(int id)
        {
            return context.ParticipationEvents.Where(p => p.Id == id).First();
        }

        public ObservableCollection<ParticipationEvent> GetList()
        {
            return new ObservableCollection<ParticipationEvent>(context.ParticipationEvents.ToList());
        }

        public void Update(ParticipationEvent item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
