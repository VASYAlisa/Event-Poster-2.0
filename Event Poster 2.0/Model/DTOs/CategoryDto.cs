using Event_Poster_2._0.Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Poster_2._0.Model.DTOs
{
    public class CategoryDto: Category
    {
        public CategoryDto() { }

        public bool IsSelected { get; set; }

        public CategoryDto(Category category) 
        {
            Id = category.Id;
            Name = category.Name;

            IsSelected = false;
        }
    }
}
