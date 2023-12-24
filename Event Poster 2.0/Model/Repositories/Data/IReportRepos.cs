using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Event_Poster_2._0.Model.DTOs.ReportDto;

namespace Event_Poster_2._0.Model.Repositories.Data
{
    public interface IReportRepos
    {
        ObservableCollection<ParticipationsByDate> ParticipationsByDate(DateTime startDate, DateTime endDate);
    }
}
