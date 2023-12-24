using Event_Poster_2._0.Model.DAL;
using Event_Poster_2._0.Model.Data;
using Event_Poster_2._0.Model.Repositories;

using Event_Poster_2._0.Utilities;
using Event_Poster_2._0.View.ViewForAdmin;
using Event_Poster_2._0.ViewModel.CRUD;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Event_Poster_2._0.ViewModel.AdminPages
{
    public class CategoriesViewModel: ViewModelBase
    {
        
        private ObservableCollection<Category> _cities;


        public ObservableCollection<Category> Categories
        {
            get { return _cities; }
            set { _cities = value; OnPropertyChanged(nameof(Categories)); }
        }

        public ICommand AddCategoryCommand { get; set; }
        public ICommand EditCategoryCommand { get; set; }

        private DbRepos context;

        public CategoriesViewModel()
        {
            context = new DbRepos();
            AddCategoryCommand = new RelayCommand(CreateCategory);
            EditCategoryCommand = new RelayCommand(EditCategory);
            
            Categories = context.Categories.GetList();
        }

        private void EditCategory(object obj)
        {
            if (obj is Category c)
            {
                EditCategory editCategory = new EditCategory();
                EditCategoryViewModel viewModel = new EditCategoryViewModel(c);
                editCategory.DataContext = viewModel;
                editCategory.Closed += (s, e) =>
                {
                    editCategory.Closed += (s, e) => context.Categories.Update(c);
                    //context = new DbRepos();
                    //context.Categories.Update(c);
                    
                };
                editCategory.Show();
            }
        }

        private void CreateCategory(object obj)
        {
            AddCategory addCategory = new AddCategory();
            AddCategoryViewModel viewModel = new AddCategoryViewModel();
            addCategory.DataContext = viewModel;
            addCategory.Closed += (s, e) => Categories = context.Categories.GetList(); ;
            addCategory.Show();
        }

    }
}
