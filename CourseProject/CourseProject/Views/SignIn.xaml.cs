using CourseProject.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace CourseProject.Views
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        public SignIn()
        {
            InitializeComponent();
            DataContext = new SignInViewModel();
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            { ((dynamic)DataContext).Password = ((PasswordBox)sender).Password; }
        }
        public void OnPasswordChanged_signIn(object sender, RoutedEventArgs e)
        {
            if (SignInPassBox.Password.Length > 0)
                SignInPassBoxWatermark.Visibility = Visibility.Collapsed;
            else
                SignInPassBoxWatermark.Visibility = Visibility.Visible;
        }
        public void GoToRegister(object sender, RoutedEventArgs e)
        {
            var regsiter = new MainWindow();
            regsiter.Show();
            Close();
        }
    }
}
