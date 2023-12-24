using Event_Poster_2._0.Model.DAL;
using Event_Poster_2._0.Model.DTOs;
using Event_Poster_2._0.Model.Repositories;
using Event_Poster_2._0.Utilities;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Event_Poster_2._0.ViewModel.CRUD
{
    class EditEventViewModel : ViewModelBase
    {
        private string _name;
        private int _price;
        private DateTime _date;
        private string _author;
        private string _description;
        private ImageSource _eventImage;
        private byte[] _image;
        private string _errorMessage;
        private ObservableCollection<Category> _selectedCategories;
        private ObservableCollection<CategoryDto> _allCategories; //CategoryDto SelectedCategories
        private ObservableCollection<City> _allCities;
        private int _cityId;

        public int CityId
        {
            get { return _cityId; }
            set { _cityId = value; OnPropertyChanged(nameof(CityId)); }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        public int Price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged(nameof(Price)); }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged(nameof(Date)); }
        }

        public string Author
        {
            get { return _author; }
            set { _author = value; OnPropertyChanged(nameof(Author)); }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged(nameof(Description)); }
        }

        public byte[] Image
        {
            get { return _image; }
            set { _image = value; OnPropertyChanged(nameof(Image)); }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
        }

        public ObservableCollection<Category> SelectedCategories
        {
            get { return _selectedCategories; }
            set { _selectedCategories = value; OnPropertyChanged(nameof(SelectedCategories)); }
        }

        public ObservableCollection<CategoryDto> AllCategories
        {
            get { return _allCategories; }
            set { _allCategories = value; OnPropertyChanged(nameof(AllCategories)); }
        }

        public ObservableCollection<City> AllCities
        {
            get { return _allCities; }
            set { _allCities = value; OnPropertyChanged(nameof(AllCities)); }
        }

        public ImageSource EventImage
        {
            get { return _eventImage; }
            set { _eventImage = value; OnPropertyChanged(nameof(EventImage)); }
        }

        public ICommand EditImageCommand { get; set; }
        public ICommand EditCategoryCommand { get; set; }
        public ICommand EditCitiesCommand { get; set; }
        public ICommand EditEventCommand { get; set; }
        public ICommand DeleteEventCommand { get; set; }

        private DbRepos context;

        private Event @event;

        public EditEventViewModel(Event _event)
        {
            context = new DbRepos();

            @event = context.Events.GetItem(_event.Id);
            Name = _event.Name;
            Author = _event.Author;
            Description = _event.Description;
            SelectedCategories = new ObservableCollection<Category>(@event.Categories);
            @event.Categories.Clear();
            Image = @event.Image;
            Price = @event.Price;
            Date = @event.Date;
            CityId = @event.CityId;

            AllCategories = new ObservableCollection<CategoryDto>(context.Categories.GetList().Select(c => new CategoryDto(c)).ToList());
            foreach (var category in AllCategories)
            {
                foreach (var selected in SelectedCategories)
                {
                    if (category.Id == selected.Id) category.IsSelected = true;
                }
            }
            AllCities = context.Cities.GetList();

            EditImageCommand = new RelayCommand(EditImage);
            EditEventCommand = new RelayCommand(EditEvent);
            EditCategoryCommand = new RelayCommand(EditCategory);
            EditCitiesCommand = new RelayCommand(EditCity);
            DeleteEventCommand = new RelayCommand(DeleteEvent);
        }

        private void EditImage(object obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == true)
            {
                Image = File.ReadAllBytes(openFileDialog.FileName);
            }
        }

        
        private void EditEvent(object obj)
        {
            if (Name == null || Description == null || Author == null || CityId == 0)
                ErrorMessage = "Заполнены не все поля"; 
            else
            {
                @event.Name = Name;
                @event.Price = Price;
                @event.Author = Author;
                @event.Description = Description;
                @event.Date = Date;
                @event.CityId = CityId;
                @event.Categories = SelectedCategories; //
                @event.Image = Image;
                @event.StatusId = 1;

                context.Events.Update(@event);
                context.Save();

                if (obj is Window window) window.Close();
            }
        }
        private void EditCategory(object obj)
        {
            if (obj is CategoryDto categories)
            {
                var ing = context.Categories.GetItem(categories.Id);
                if (categories.IsSelected)
                {

                    SelectedCategories.Add(ing);
                }
                else
                {

                    SelectedCategories.Remove(ing);
                }
            }
        }
        private void EditCity(object obj)
        {
            throw new NotImplementedException();
        }
        private void DeleteEvent(object obj)
        {
            context.Events.Delete(@event.Id);
            context.Save();

            if (obj is Window window) window.Close();
        }

    }
}
