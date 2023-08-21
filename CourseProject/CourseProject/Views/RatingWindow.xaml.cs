using CourseProject.ViewModels;
using System.Windows;

namespace CourseProject.Views
{
    /// <summary>
    /// Interaction logic for RatingWindow.xaml
    /// </summary>
    public partial class RatingWindow : Window
    {
        public RatingWindow()
        {
            InitializeComponent();
            DataContext = new RatingWindowViewModel();
        }
    }
}
