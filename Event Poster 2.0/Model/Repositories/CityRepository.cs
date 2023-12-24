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
    public class CityRepository : IRepository<City>
    {
        EventContext context;

        public CityRepository(EventContext _context) 
        { 
            this.context = _context;
        }

        public void Create(City item)
        {
            context.Cities.Add(item);
        }

        public void Delete(int id)
        {
            City city = context.Cities.Find(id);
            if (city != null)
                context.Cities.Remove(city);
        }

        public City GetItem(int id)
        {
            return context.Cities.Where(p => p.Id == id).First();
        }

        public ObservableCollection<City> GetList()
        {
            return new ObservableCollection<City>(context.Cities.ToList());
        }

        public void Update(City item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
