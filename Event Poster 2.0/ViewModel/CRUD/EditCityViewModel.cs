using Event_Poster_2._0.Model.DAL;
using Event_Poster_2._0.Model.Repositories;

using Event_Poster_2._0.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Event_Poster_2._0.ViewModel.CRUD
{
    public class EditCityViewModel : ViewModelBase
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

        public ICommand EditCityCommand { get; set; }
        public ICommand DeleteCityCommand { get; set; }

        City city;

        private DbRepos context;

        //public EditCityViewModel() { }
        public EditCityViewModel(City _city)
        {
            context= new DbRepos();

            city = _city;
            Name = city.Name;

            EditCityCommand = new RelayCommand(EditCity);
            DeleteCityCommand = new RelayCommand(DeleteCity);
        }

        private void EditCity(object obj)
        {
            if (Name == null) ErrorMessage = "Заполнены не все поля";
            else
            {
                city.Name = Name;

                context.Cities.Update(city);
                context.Save();

                if (obj is Window window) window.Close();
            }
        }

        private void DeleteCity(object obj)
        {
            context.Cities.Delete(city.Id);
            context.Save();

            if (obj is Window window) window.Close();
        }
    }
}
