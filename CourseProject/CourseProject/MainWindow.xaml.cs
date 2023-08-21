using CourseProject.ViewModels;
using CourseProject.Views;
using System.Windows;
using System.Windows.Controls;

namespace CourseProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new RegistrationViewModel();
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            { ((dynamic)DataContext).Password = ((PasswordBox)sender).Password; }
        }
        private void PasswordBox_PasswordConfirmChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            { ((dynamic)DataContext).PasswordConfirm = ((PasswordBox)sender).Password; }
        }
        public void OnPasswordChanged_reg(object sender, RoutedEventArgs e)
        {
            if (RegPassBox.Password.Length > 0)
                RegPassBoxWatermark.Visibility = Visibility.Collapsed;
            else
                RegPassBoxWatermark.Visibility = Visibility.Visible;
        }
        public void OnPasswordChanged_regConfirm(object sender, RoutedEventArgs e)
        {
            if (RegPassBoxConfirm.Password.Length > 0)
                RegPassBoxWatermarkConfirm.Visibility = Visibility.Collapsed;
            else
                RegPassBoxWatermarkConfirm.Visibility = Visibility.Visible;
        }
        public void GoToSignIn(object sender, RoutedEventArgs e)
        {
            var signIn = new SignIn();
            signIn.Show();
            Close();
        }
    }
}
