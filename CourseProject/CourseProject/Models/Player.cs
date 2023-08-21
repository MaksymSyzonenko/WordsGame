using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CourseProject.Models
{
    public class Player : INotifyPropertyChanged
    {
        private string login;
        private string password;
        private int guessedWords;
        private int completedLevels;
        private int rank;
        public string Login { get => login; set { login = value; OnPropertyChanged(); } }
        public string Password { get => password; set { password = value; OnPropertyChanged(); } }
        public int GuessedWords { get => guessedWords; set { guessedWords = value; OnPropertyChanged(); } }
        public int CompletedLevels { get => completedLevels; set { completedLevels = value; OnPropertyChanged(); } }
        public int Rank { get => rank; set { rank = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
