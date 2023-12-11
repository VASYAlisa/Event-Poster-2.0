using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Poster_2._0.Model.DAL
{
    public class Event
    {
        public int Id { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("Цена")]
        public int Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yy}")]
        public DateTime Date { get; set; }

        [DisplayName("Автор")]
        public string Author { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }


        public int CategoryId { get; set; }
        //[ValidateNever]
        [DisplayName("Категория")]
        public Category Category { get; set; }

        //public List<Category> Categories { get; set; } = new();
        public int StatusId { get; set; }
        //[ValidateNever]
        [DisplayName("Категория")]
        public Status Status { get; set; }

        public int CityId { get; set; }
        //[ValidateNever]
        [DisplayName("Категория")]
        public City City { get; set; }
        
    }
}
