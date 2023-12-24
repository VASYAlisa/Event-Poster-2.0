using Event_Poster_2._0.Model.DAL;
using Microsoft.EntityFrameworkCore;


namespace Event_Poster_2._0.Model.Data
{
    public class EventContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Participation> Participations { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UsersTypes { get; set; }

        public DbSet<ParticipationEvent> ParticipationEvents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=VASILISA\SQLEXPRESS; Initial catalog=EventPoster2; Trusted_Connection=True; TrustServerCertificate=True;");
        }
    }
}
