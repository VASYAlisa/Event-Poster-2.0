using Event_Poster_2._0.Model.Data;
using Event_Poster_2._0.Model.Repositories;
using Event_Poster_2._0.Utilities;
using Event_Poster_2._0.View;
using System;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace Event_Poster_2._0.ViewModel
{
    class LoginViewModel:ViewModelBase
    {
        //EventContext context;
        DbRepos context;
        //Fields
        private string _username;
        private string _password;
        private string _errorMessage;
        private bool _isViewVisible = true;
        
        //Properties

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public bool IsViewVisible
        {
            get
            {
                return _isViewVisible;
            }
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }



        //-> Commands
        public ICommand LoginCommand { get; }

        public ICommand RegistrationCommand { get; set; }


        //Constructor
        public LoginViewModel()
        {
            //context = new EventContext();
            context= new DbRepos();

            LoginCommand = new RelayCommand(Login);
            RegistrationCommand  = new RelayCommand(Registration);
        }

        //Проверка чтобы пароль и логин были не менее 3 символов, кнопка логин вкл только в этом случае
        private void Registration(object obj)
        {
            var regView = new RegistrationView();
            regView.Show();
            if (obj is Window window) window.Close();
        }

        private void Login(object obj)
        {
            var user = context.Users.GetList().Where(u => u.Password == Password && u.UserName == Username).FirstOrDefault();
            if (user != default)
            {
                if (user.UserTypeId == 2)
                {
                    var clientWindow = new ClientWindow();
                    var viewModel = new UserViewModel(user);
                    clientWindow.DataContext = viewModel;
                    clientWindow.Show();
                }
                else if (user.UserTypeId == 1)
                {
                    var adminWindow = new AdminWindow();
                    adminWindow.Show();
                }
                if (obj is Window window) window.Close();
            }
            else ErrorMessage = "Данные введены некорректно";
        }
    }
}
