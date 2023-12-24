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
    public class UserTypeRepository : IRepository<UserType>

    {
        EventContext context;

        public UserTypeRepository(EventContext _context)
        {
            this.context = _context;
        }
        public void Create(UserType item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public UserType GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<UserType> GetList()
        {
            throw new NotImplementedException();
        }

        public void Update(UserType item)
        {
            throw new NotImplementedException();
        }
    }
}
