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
    public class ParticipationRepository : IRepository<Participation>

    {
        EventContext context;

        public ParticipationRepository(EventContext _context)
        {
            this.context = _context;
        }
        public void Create(Participation item)
        {
            context.Participations.Add(item);
        }

        public void Delete(int id)
        {
            Participation p = context.Participations.Find(id);
            if (p != null)
                context.Participations.Remove(p);
        }

        public Participation GetItem(int id)
        {
            return context.Participations.Where(p => p.Id == id).First();
        }

        public ObservableCollection<Participation> GetList()
        {
            return new ObservableCollection<Participation>(context.Participations.ToList());
        }

        public void Update(Participation item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
