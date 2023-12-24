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
    public class UserRepository : IRepository<User>

    {
        EventContext context;

        public UserRepository(EventContext _context)
        {
            this.context = _context;
        }
        public void Create(User item)
        {
            context.Users.Add(item);
        }

        public void Delete(int id)
        {
            User User = context.Users.Find(id);
            if (User != null)
                context.Users.Remove(User);
        }

        public User GetItem(int id)
        {
            return context.Users.Find(id);
        }

        public ObservableCollection<User> GetList()
        {
            return new ObservableCollection<User>(context.Users.ToList());
        }

        public void Update(User item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
