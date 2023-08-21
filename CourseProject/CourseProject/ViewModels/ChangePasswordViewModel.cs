using CourseProject.Commands;
using CourseProject.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace CourseProject.ViewModels
{
    public class ChangePasswordViewModel : INotifyPropertyChanged
    {
        private string errorMessage;
        private string login;
        public string Password { private get; set; }
        public string NewPassword { private get; set; }
        public string NewPasswordConfirm { private get; set; }
        public string Login { get => login; set { login = value; OnPropertyChanged(); } } 
        public string ErrorMessage { get => errorMessage; set { errorMessage = value; OnPropertyChanged(); } }
        public ChangePasswordViewModel(string login)
        {
            Login = login;
        }
        private RelayCommand? changePasswordCommand;
        public RelayCommand ChangePasswordCommand
        {
            get
            {
                return changePasswordCommand ??= new RelayCommand(obj =>
                {
                    ErrorMessage = string.Empty;
                    if (NewPassword == NewPasswordConfirm)
                    {
                        BasePlayers basePlayers = new BasePlayers("Players.json");
                        ErrorMessage = basePlayers.ChangePassword(Login, Password, NewPassword);
                        if (ErrorMessage == string.Empty)
                        {
                            MessageBox.Show("Пароль успішно змінено!");
                            ((Window)obj).Close();
                        }
                    }
                    else
                        ErrorMessage = "Паролі не співпадають!";
                });
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
