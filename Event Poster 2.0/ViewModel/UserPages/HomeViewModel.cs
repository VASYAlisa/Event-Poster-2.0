using Event_Poster_2._0.Model.Repositories;
using Event_Poster_2._0.Utilities;
using Event_Poster_2._0.Model.DAL;
using System.Windows.Input;
using System.Linq;
using System.Net;

namespace Event_Poster_2._0.ViewModel.UserPages
{
    public class HomeViewModel : ViewModelBase
    {
        private string _name;
        private string _email;
        private string _username;
        private string _password;
        private string _newPassword;
        private string _errorMessage;

        public string Name { get => _name; set { _name = value; OnPropertyChanged(nameof(Name)); } }
        public string Email { get => _email; set { _email = value; OnPropertyChanged(nameof(Email)); } }
        public string Username { get => _username; set { _username = value; OnPropertyChanged(nameof(Username)); } }
        public string Password { get => _password; set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public string NewPassword { get => _newPassword; set { _newPassword = value; OnPropertyChanged(nameof(NewPassword)); } }
        public string ErrorMessage { get => _errorMessage; set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); } }

        public ICommand SaveChangesCommand { get; set; }

        private Participant _participant;
        private DbRepos context;
        public HomeViewModel(Participant participant) 
        {
            context = new DbRepos();
            _participant = context.Participants.GetList().First(c => c.Id == participant.Id);
            Name = _participant.Name;
            
            if (_participant.Email != null) Email = _participant.Email;
            Username = _participant.User.UserName;

            SaveChangesCommand = new RelayCommand(SaveChanges);

        }

        private void SaveChanges(object obj)
        {
            bool canSave = true;
            if (string.IsNullOrWhiteSpace(Name))
            {
                ErrorMessage = "Не все поля заполнены";
                canSave = false;
            }
            else _participant.Name = Name;
            
            _participant.Email = Email;//проверка?

            if (string.IsNullOrWhiteSpace(Username))
            {
                ErrorMessage = "Не все поля заполнены";
                canSave = false;
            }
            else if (Username != _participant.User.UserName)
            {
                var exist = context.Users.GetList().FirstOrDefault(u => u.UserName == Username);
                if (exist == null) _participant.User.UserName = Username;
                else
                {
                    ErrorMessage = "Имя пользователя занято";
                    canSave = false;
                }
            }
            if (_participant.User.Password != Password)
            {
                ErrorMessage = "Неверный пароль";
                canSave = false;
            }
            if (!string.IsNullOrWhiteSpace(NewPassword)) _participant.User.Password = NewPassword;

            if (canSave)
            {
                ErrorMessage = "Данные успешно изменены";
                context.Participants.Update(_participant);
                context.Save();
                context.Users.Update(_participant.User);
                context.Save();
            }
        }
    }
}
