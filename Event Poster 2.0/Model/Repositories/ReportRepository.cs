using Event_Poster_2._0.Model.Data;
using Event_Poster_2._0.Model.DTOs;
using Event_Poster_2._0.Model.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Event_Poster_2._0.Model.DTOs.ReportDto;

namespace Event_Poster_2._0.Model.Repositories
{
    public class ReportRepository : IReportRepos
    {
        private EventContext context;

        public ReportRepository(EventContext _context)
        {
            this.context = _context;
        }
        public ObservableCollection<ParticipationsByDate> ParticipationsByDate(DateTime startDate, DateTime endDate)
        {


            var ordersByMonth = new ObservableCollection<ParticipationsByDate>(context.Participations.OrderByDescending(o => o.Date)
            .Where(o => o.Date.Date >= startDate.Date && o.Date.Date <= endDate.Date)
            .Select(g => new ParticipationsByDate()
            {
                Date = g.Date.ToString("dd.MM.yyyy"),
                Time = g.Date.ToShortTimeString(),
                Events = FormatList(string.Join(",", g.ParticipationEvents.Select(i => i.Event.Name).ToList())),
                Participant = g.Participant.Name,
                Price = g.Price
            })
            .ToList()) ;
            return ordersByMonth;
        }

        public static string FormatList(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            var events = input.Split(',');
            var ing = events[0];
            events[0] = char.ToUpper(ing[0]) + ing.Substring(1);
            for (int i = 1; i < events.Length; i++)
            {
                events[i] = CultureInfo.CurrentCulture.TextInfo.ToLower(events[i].Trim());
            }
            return string.Join(", ", events);
        }
    }
}
