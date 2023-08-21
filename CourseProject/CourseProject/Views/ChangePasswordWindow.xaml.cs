using CourseProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CourseProject.Views
{
    /// <summary>
    /// Interaction logic for ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        public ChangePasswordWindow(string login)
        {
            InitializeComponent();
            DataContext = new ChangePasswordViewModel(login);
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            { ((dynamic)DataContext).Password = ((PasswordBox)sender).Password; }
        }
        private void PasswordBox_NewPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            { ((dynamic)DataContext).NewPassword = ((PasswordBox)sender).Password; }
        }
        private void PasswordBox_NewPasswordConfirmChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            { ((dynamic)DataContext).NewPasswordConfirm = ((PasswordBox)sender).Password; }
        }
        public void OnPasswordChanged_change(object sender, RoutedEventArgs e)
        {
            if (ChangePassBox.Password.Length > 0)
                ChangePassBoxWatermark.Visibility = Visibility.Collapsed;
            else
                ChangePassBoxWatermark.Visibility = Visibility.Visible;
        }
        public void OnPasswordChanged_changeNew(object sender, RoutedEventArgs e)
        {
            if (ChangeNewPassBox.Password.Length > 0)
                ChangeNewPassBoxWatermark.Visibility = Visibility.Collapsed;
            else
                ChangeNewPassBoxWatermark.Visibility = Visibility.Visible;
        }
        public void OnPasswordChanged_changeNewConfirm(object sender, RoutedEventArgs e)
        {
            if (ChangeNewPassBoxConfirm.Password.Length > 0)
                ChangeNewPassBoxWatermarkConfirm.Visibility = Visibility.Collapsed;
            else
                ChangeNewPassBoxWatermarkConfirm.Visibility = Visibility.Visible;
        }
    }
}
