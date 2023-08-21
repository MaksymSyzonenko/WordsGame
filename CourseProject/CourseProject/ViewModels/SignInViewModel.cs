using CourseProject.Commands;
using CourseProject.Models;
using CourseProject.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace CourseProject.ViewModels
{
    public class SignInViewModel : INotifyPropertyChanged
    {
        private string errorMessage;
        private string login;
        private string password;
        public string ErrorMessage { get => errorMessage; set { errorMessage = value; OnPropertyChanged(); } }
        public string Login { get => login; set { login = value; OnPropertyChanged(); } }
        public string Password { get => password; set { password = value; OnPropertyChanged(); } }
        private RelayCommand? signInCommand;
        public RelayCommand SignInCommand
        {
            get
            {
                return signInCommand ??= new RelayCommand(obj =>
                {
                      ErrorMessage = string.Empty;
                      BasePlayers basePlayers = new BasePlayers("Players.json");
                      if (basePlayers.FindPlayer(Login, Password))
                      {
                          MessageBox.Show($"Вхід в аккаунт {Login} успішний!\nДля отримання інформації про правила гри, натисніть кнопку Manual, у розділі Settings.");
                          var gameWindow = new GameWindow(Login, Password);
                          gameWindow.Show();
                          ((Window)obj).Close();
                      }
                      else
                          ErrorMessage = "Не вірний логін або пароль!";
                });
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
