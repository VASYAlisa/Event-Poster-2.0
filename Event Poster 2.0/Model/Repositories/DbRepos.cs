using Event_Poster_2._0.Model.DAL;
using Event_Poster_2._0.Model.Data;
using Event_Poster_2._0.Model.Repositories.Data;

namespace Event_Poster_2._0.Model.Repositories
{
    public class DbRepos : IDbRepos
    {
        private EventContext context;
        private EventRepository eventRepository;
        private CategoryRepository categoryRepository;
        private CityRepository cityRepository;
        private ParticipantRepository participantRepository;
        private ParticipationRepository participationRepository;
        private StatusRepository statusRepository;
        private UserRepository userRepository;
        private UserTypeRepository userTypeRepository;
        private ParticipationEventRepository participationEventRepository;
        private ReportRepository reportRepository;
        public DbRepos() 
        {
            context= new EventContext();
        }

        public IReportRepos Reports
        {
            get
            {
                if (reportRepository == null)
                    reportRepository = new ReportRepository(context);
                return reportRepository;
            }
        }
        public IRepository<Event> Events
        {
            get
            {
                if (eventRepository == null)
                    eventRepository = new EventRepository(context);
                return eventRepository;
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(context);
                return categoryRepository;
            }
        }

        public IRepository<City> Cities
        {
            get
            {
                if (cityRepository == null)
                    cityRepository = new CityRepository(context);
                return cityRepository;
            }
        }

        public IRepository<Participation> Participations
        {
            get
            {
                if (participationRepository == null)
                    participationRepository = new ParticipationRepository(context);
                return participationRepository;
            }
        }

        public IRepository<Participant> Participants
        {
            get
            {
                if (participantRepository == null)
                    participantRepository = new ParticipantRepository(context);
                return participantRepository;
            }
        }

        public IRepository<Status> Statuses
        {
            get
            {
                if (statusRepository == null)
                    statusRepository = new StatusRepository(context);
                return statusRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(context);
                return userRepository;
            }
        }

        public IRepository<UserType> UserTypes
        {
            get
            {
                if (userTypeRepository == null)
                    userTypeRepository = new UserTypeRepository(context);
                return userTypeRepository;
            }
        }

        public IRepository<ParticipationEvent> ParticipationEvents
        {
            get
            {
                if (participationEventRepository == null)
                    participationEventRepository = new ParticipationEventRepository(context);
                return participationEventRepository;
            }
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
