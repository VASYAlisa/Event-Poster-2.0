using Event_Poster_2._0.Model.DAL;
using Event_Poster_2._0.Model.Data;
using Event_Poster_2._0.Model.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Poster_2._0.Model.Repositories
{
    public class StatusRepository : IRepository<Status>

    {
        EventContext context;

        public StatusRepository(EventContext _context)
        {
            this.context = _context;
        }
        public void Create(Status item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Status GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Status> GetList()
        {
            throw new NotImplementedException();
        }

        public void Update(Status item)
        {
            throw new NotImplementedException();
        }
    }
}
