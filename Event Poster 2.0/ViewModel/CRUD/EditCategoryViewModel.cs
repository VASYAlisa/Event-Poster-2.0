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
    public class EditCategoryViewModel : ViewModelBase
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

        public ICommand EditCategoryCommand { get; set; }
        
        private Category category;

        private DbRepos context;
        public EditCategoryViewModel(Category _category)
        {
            context= new DbRepos();

            category = _category;
            Name = category.Name;

            EditCategoryCommand = new RelayCommand(EditCategory);
            

        }

        private void EditCategory(object obj)
        {
            if (Name == null) ErrorMessage = "Заполнены не все поля";
            else
            {
                category.Name = Name;

                context.Categories.Update(category);
                context.Save();

                if (obj is Window window) window.Close();
            }
        }

    }
}
