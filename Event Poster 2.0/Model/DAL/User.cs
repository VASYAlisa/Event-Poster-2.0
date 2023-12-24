

namespace Event_Poster_2._0.Model.DAL
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public int UserTypeId { get; set; }
        
        public UserType UserType { get; set; }
    }
}
