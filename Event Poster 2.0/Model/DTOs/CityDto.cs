using Event_Poster_2._0.Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Poster_2._0.Model.DTOs
{
    public class CityDto:City
    {
        public CityDto() { }
        public bool IsSelected { get; set; }

        public CityDto(City city)
        {
            Id = city.Id;
            Name = city.Name;

            IsSelected = false;
        }
    }
}
