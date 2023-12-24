using Event_Poster_2._0.Model.DAL;
using Event_Poster_2._0.Model.DTOs;

using Event_Poster_2._0.Utilities;
using System;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.ObjectModel;
using Event_Poster_2._0.Model.Repositories;

namespace Event_Poster_2._0.ViewModel.CRUD
{
    public class AddEventViewModel : ViewModelBase
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
        private ObservableCollection<CategoryDto> _allCategories;
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

        public ICommand AddImageCommand { get; set; }
        public ICommand SelectCategoryCommand { get; set; }
        public ICommand SelectCitiesCommand { get; set; }
        public ICommand AddEventCommand { get; set; }

        
        private DbRepos context;

        public AddEventViewModel()
        {
            context = new DbRepos();
            Date= DateTime.Now;

            AddImageCommand = new RelayCommand(AddImage);
            AddEventCommand = new RelayCommand(CreateEvent);
            SelectCategoryCommand = new RelayCommand(SelectCategory);
            SelectCitiesCommand = new RelayCommand(SelectCity);

            AllCategories = new ObservableCollection<CategoryDto>(context.Categories.GetList().Select(c => new CategoryDto(c)).ToList());
            SelectedCategories = new ObservableCollection<Category>();
            
            AllCities = context.Cities.GetList();
            
        }

        private void SelectCity(object obj)
        {

        }

        private void SelectCategory(object obj)
        {
            if (obj is CategoryDto category)
            {
                var cat = context.Categories.GetItem(category.Id);
                if (category.IsSelected)
                {
                    SelectedCategories.Add(cat);
                }
                else
                {
                    SelectedCategories.Remove(cat);
                }
            }
        }

        private void CreateEvent(object obj)
        {
            if (Name == null || Description == null || Author == null || CityId == 0)
                ErrorMessage = "Заполнены не все поля"; // доделать проверку сити и тд
            else
            {
                Event newEvent = new Event();

                newEvent.Name = Name;
                newEvent.Price = Price;
                newEvent.Author = Author;
                newEvent.Description = Description;
                newEvent.Date = Date;
                newEvent.CityId = CityId;
                //foreach (var cat in SelectedCategories) 
                //{
                //    newEvent.Categories.Add(categoryService.GetCategoryById(cat.Id));
                //}
                newEvent.Categories = SelectedCategories;
                
                newEvent.Image = Image;
                newEvent.StatusId = 1;

                context.Events.Create(newEvent);
                context.Save();

                if (obj is Window window) window.Close();
            }
        }

        private void AddImage(object obj)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == true) //проверка
            {
                BitmapImage bitmap = new BitmapImage(new Uri(openFileDialog.FileName));
                _eventImage = bitmap;
                Image = File.ReadAllBytes(openFileDialog.FileName);
            }
        }
    }
}
