using Event_Poster_2._0.Model.DAL;
using Event_Poster_2._0.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Poster_2._0.ViewModel.UserWindows
{
    public class ViewEventViewModel : ViewModelBase
    {
        private string _name;
        private int _price;
        private string _author;
        private string _description;
        private string _city;
        private string _date;
        private string _categories;
        private byte[] _image;
        private Event _selectedEvent;

        

        public string Categories
        {
            get { return _categories; }
            set { _categories = value; OnPropertyChanged(nameof(Categories)); }
        }

        

        public Event SelectedEvent
        {
            get { return _selectedEvent; }
            set { _selectedEvent = value; OnPropertyChanged(nameof(SelectedEvent)); }
        }

       

        public ViewEventViewModel(Event ev)
        {
            SelectedEvent= ev;
            string categoryArray = string.Join(",", SelectedEvent.Categories.Select(i => i.Name).ToList());
            Categories = FormatList(categoryArray);
        }

        private string FormatList(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            var categories = input.Split(',');
            var ing = categories[0];
            categories[0] = char.ToUpper(ing[0]) + ing.Substring(1);
            for (int i = 1; i < categories.Length; i++)
            {
                categories[i] = CultureInfo.CurrentCulture.TextInfo.ToLower(categories[i].Trim());
            }
            return string.Join(", ", categories);
        }
    }
}
