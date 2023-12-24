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
    public class CategoryRepository : IRepository<Category>
    {
        EventContext context;

        public CategoryRepository(EventContext _context) 
        { 
            this.context = _context;
        }
        public void Create(Category item)
        {
            context.Categories.Add(item);
        }

        public void Delete(int id)
        {
            Category category = context.Categories.Find(id);
            if (category != null)
                context.Categories.Remove(category);
        }

        public Category GetItem(int id)
        {
            return context.Categories.Where(p => p.Id == id).First();
        }

        public ObservableCollection<Category> GetList()
        {
            return new ObservableCollection<Category>(context.Categories.ToList());
        }

        public void Update(Category item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
