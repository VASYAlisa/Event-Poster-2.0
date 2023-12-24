using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace UnitTests.DAL
{
    public class Event
    {
        public int Id { get; set; }

        
        public string Name { get; set; }

        
        public int Price { get; set; }

        
        public DateTime Date { get; set; }

        
        public string Author { get; set; }

        
        public string Description { get; set; }

        


        

        public List<Category> Categories { get; set; } = new();
        //public int StatusId { get; set; }
        
        //public Status Status { get; set; }

        //public int CityId { get; set; }
        
        //public City City { get; set; }
        
    }
}
