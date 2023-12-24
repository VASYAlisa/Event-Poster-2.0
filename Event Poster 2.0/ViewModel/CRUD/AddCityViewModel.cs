using Event_Poster_2._0.Model.DAL;
using Event_Poster_2._0.Model.Repositories;

using Event_Poster_2._0.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Event_Poster_2._0.ViewModel.CRUD
{
    public class AddCityViewModel : ViewModelBase
    {
        private string _name;
        private string _errorMessage;
        
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
        }

        public ICommand AddCityCommand { get; set; }

        private DbRepos context;
        public AddCityViewModel()
        {
            context = new DbRepos();

            AddCityCommand = new RelayCommand(CreateCity);
        }

        private void CreateCity(object obj)
        {
            if (Name == null) ErrorMessage = "Заполнены не все поля";
            else
            {
                City newCity = new City();

                newCity.Name = Name;

                context.Cities.Create(newCity);
                context.Save();

                if (obj is Window window) window.Close();
            }
        }
    }
}
