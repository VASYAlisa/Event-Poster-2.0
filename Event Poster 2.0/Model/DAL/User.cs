using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Poster_2._0.Model.DAL
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public int UserTypeId { get; set; }
        //[ValidateNever]
        [DisplayName("Тип пользователя")]
        public UserType UserType { get; set; }
    }
}
