using CourseProject.Commands;
using CourseProject.Models;
using CourseProject.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace CourseProject.ViewModels
{
    public class RegistrationViewModel : INotifyPropertyChanged
    {
        private string errorMessage;
        public string Password { private get; set; }
        public string PasswordConfirm { private get; set; }
        public string ErrorMessage { get => errorMessage; set { errorMessage = value; OnPropertyChanged(); } }
        private RelayCommand? addPlayerCommand;
        public RelayCommand AddPlayerCommand
        {
            get
            {
                return addPlayerCommand ??= new RelayCommand(obj =>
                {
                    ErrorMessage = string.Empty;
                    if (obj is Player player)
                    {
                        if (Password == PasswordConfirm)
                        {
                            BasePlayers basePlayers = new("Players.json");
                            player.Password = Password;
                            ErrorMessage = basePlayers.RegisterPlayer(player);
                            if (ErrorMessage == string.Empty)
                            {
                                MessageBox.Show("Реєстрація успішна! Зараз триватиме завантаження бази слів для вашого аккаунту," +
                                    " це може зайняти деякий час(приблизно 15 секунд), коли шкала прогресу досягне кінця з'явиться повідомлення," +
                                    " після цього ви можете перейти до вікна авторизації. Чекайте!");
                                CreateWordList(player.Login);
                                var loadingWindow = new LoadingWindow();
                                loadingWindow.Show();
                            }
                        }
                        else
                            ErrorMessage = "Паролі не сходяться!";
                    }
                });
            }
        }
        public static async void CreateWordList(string catalogPath) => await Task.Run(() => { var wordList = new WordList(catalogPath); });

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
