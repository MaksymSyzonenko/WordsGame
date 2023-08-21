using CourseProject.Commands;
using CourseProject.Models;
using CourseProject.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace CourseProject.ViewModels
{
    public class GameWindowViewModel : INotifyPropertyChanged
    {
        private readonly BasePlayers basePlayers = new("Players.json");
        private string login;
        private string password;
        private int rank;
        private int completedLevels;
        private int guessedWords;
        public string Login { get => login; set { login = value; OnPropertyChanged(); } }
        public string Password { get => password; set { password = value; OnPropertyChanged(); } }
        public int Rank { get => rank; set { rank = value; OnPropertyChanged(); } }
        public int CompletedLevels { get => completedLevels; set { completedLevels = value; OnPropertyChanged(); } }
        public int GuessedWords { get => guessedWords; set { guessedWords = value; OnPropertyChanged(); } }
        public GameWindowViewModel(string login, string password)
        {
            var player = basePlayers.GetPlayer(login, password);
            Login = login;
            Password = password;
            Rank = player.Rank;
            CompletedLevels = player.CompletedLevels;
            GuessedWords = player.GuessedWords;
        }
        private RelayCommand? changePasswordCommand;
        public RelayCommand ChangePasswordCommand
        {
            get
            {
                return changePasswordCommand ??= new RelayCommand(obj =>
                {
                    var changePasswordWindow = new ChangePasswordWindow(Login);
                    changePasswordWindow.Show();
                });
            }
        }
        private RelayCommand? logOutCommand;
        public RelayCommand LogOutCommand
        {
            get
            {
                return logOutCommand ??= new RelayCommand(obj =>
                {
                    if (MessageBox.Show("Ви впевнені що хочете вийти з аккаунту?", "Log Out", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        var signIn = new SignIn();
                        signIn.Show();
                        ((Window)obj).Close();
                    }
                });
            }
        }     
        private RelayCommand? removeAccountCommand;
        public RelayCommand RemoveAccountCommand
        {
            get
            {
                return removeAccountCommand ??= new RelayCommand(obj =>
                {
                    if (MessageBox.Show("Ви впевнені що хочете видалити аккаунт?", "Remove Account", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        basePlayers.RemovePlayer(Login);
                        var signIn = new SignIn();
                        signIn.Show();
                        ((Window)obj).Close();
                    }
                });
            }
        }
        private RelayCommand? showManualCommand;
        public RelayCommand ShowManualCommand
        {
            get
            {
                return showManualCommand ??= new RelayCommand(obj =>
                {
                    var manualWindow = new ManualWindow();
                    manualWindow.Show();
                });
            }
        }
        private RelayCommand? showRatingCommand;
        public RelayCommand ShowRatingCommand
        {
            get
            {
                return showRatingCommand ??= new RelayCommand(obj =>
                {
                    var ratingWindow = new RatingWindow();
                    ratingWindow.Show();
                });
            }
        }
        private RelayCommand? changeSkillCommand;
        public RelayCommand ChangeSkillCommand
        {
            get
            {
                return changeSkillCommand ??= new RelayCommand(obj =>
                {
                    var player = basePlayers.GetPlayer(Login, Password);
                    Rank = player.Rank;
                    CompletedLevels = player.CompletedLevels;
                    GuessedWords = player.GuessedWords;
                });
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
