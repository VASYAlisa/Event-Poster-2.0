using Event_Poster_2._0.Model.DAL;
using Event_Poster_2._0.Model.Data;
using Event_Poster_2._0.Model.Repositories;
using Event_Poster_2._0.Utilities;
using Event_Poster_2._0.View.ViewForAdmin;
using Event_Poster_2._0.ViewModel.CRUD;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Event_Poster_2._0.ViewModel.AdminPages
{
    public class CitiesViewModel : ViewModelBase
    {
        private ObservableCollection<City> _cities;
        

        public ObservableCollection<City> Cities
        {
            get { return _cities; }
            set { _cities = value; OnPropertyChanged(nameof(Cities)); }
        }

        public ICommand AddCityCommand { get; set; }
        public ICommand EditCityCommand { get; set; }

        private DbRepos context;

        public CitiesViewModel() 
        {
            context = new DbRepos();

            AddCityCommand = new RelayCommand(CreateCity);
            EditCityCommand = new RelayCommand(EditCity);
            
            Cities = context.Cities.GetList();
        }

        private void EditCity(object obj)
        {
            if (obj is City ev)
            {
                EditCity editCity = new EditCity();
                EditCityViewModel viewModel = new EditCityViewModel(ev);
                editCity.DataContext = viewModel;
                editCity.Closed += (s, e) =>
                {
                    editCity.Closed += (s, e) => Cities = context.Cities.GetList();
                };
                editCity.Show();
            }
        }

        private void CreateCity(object obj)
        {
            AddCity addCity = new AddCity();
            AddCityViewModel viewModel = new AddCityViewModel();
            addCity.DataContext = viewModel;
            addCity.Closed += (s, e) => Cities = context.Cities.GetList();
            addCity.Show();
        }

    }
}
