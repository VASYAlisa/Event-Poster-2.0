using Event_Poster_2._0.Model.DAL;
using Event_Poster_2._0.Model.Data;
using Event_Poster_2._0.Utilities;
using Event_Poster_2._0.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Event_Poster_2._0.ViewModel
{
    class RegistrationViewModel:ViewModelBase
    {
        private string _name;
        private string _username;
        private string _password;
        private string _errorMessage;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

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

        public ICommand RegistrCommand { get; set; }

        EventContext context;

        public RegistrationViewModel()
        {
            context = new EventContext();
            RegistrCommand = new RelayCommand(Registration);
        }

        private void Registration(object obj)
        {
            if (Name == null || Password == null || Username == null)
                ErrorMessage = "Не все поля заполнены";
            else
            {
                if (Username == context.Users.Where(i => i.UserName == Username).Select(i => i.UserName).FirstOrDefault())
                    ErrorMessage = "Имя пользователя занято";
                else
                {
                    User user = new User();
                    user.Name = Name;
                    user.UserName = Username;
                    user.Password = Password;
                    user.UserTypeId = 2;
                    context.Users.Add(user);
                    context.SaveChanges();

                    Participant participant = new Participant();
                    participant.Name = Name;
                    participant.UserId = context.Users.Where(i => i.UserName == user.UserName).Select(i => i.Id).First();
                    context.Participants.Add(participant);
                    context.SaveChanges();
                    var clientWindow = new ClientWindow();
                    clientWindow.Show();
                    if (obj is Window window) window.Close();
                }
            }
        }
    }
}
