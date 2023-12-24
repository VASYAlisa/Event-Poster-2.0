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
    public class ParticipantRepository : IRepository<Participant>
    {
        EventContext context;

        public ParticipantRepository(EventContext _context)
        {
            this.context = _context;
        }

        public void Create(Participant item)
        {
            context.Participants.Add(item);
        }

        public void Delete(int id)
        {
            Participant Participant = context.Participants.Find(id);
            if (Participant != null)
                context.Participants.Remove(Participant);
        }

        public Participant GetItem(int id)
        {
            return context.Participants.Find(id);
        }

        public ObservableCollection<Participant> GetList()
        {
            return new ObservableCollection<Participant>(context.Participants.Include(u => u.User).ToList());
        }

        public void Update(Participant item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
