using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Poster_2._0.Model.DTOs
{
    public class ReportDto : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime StartData { get; set; }
        public DateTime EndData { get; set; }

        private ObservableCollection<ParticipationsByDate> _participations;
        public ObservableCollection<ParticipationsByDate> Participations { get => _participations; set { _participations = value; OnPropertyChanged(nameof(Participations)); } }

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public class ParticipationsByDate
        {
            public string Date { get; set; }
            public string Time { get; set; }
            public string Events { get; set; }
            public string Participant { get; set; }
            public int Price { get; set; }
        }
    }
}
