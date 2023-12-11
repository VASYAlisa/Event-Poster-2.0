using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Poster_2._0.Model.DAL
{
    public class UserType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Тип пользователя")]
        public string Name { get; set; }
    }
}
