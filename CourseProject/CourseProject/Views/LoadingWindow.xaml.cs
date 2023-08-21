using CourseProject.Services;
using System.ComponentModel;
using System.Windows;

namespace CourseProject.Views
{
    /// <summary>
    /// Interaction logic for LoadingWindow.xaml
    /// </summary>
    public partial class LoadingWindow : Window
    {
        public LoadingWindow()
        {
            InitializeComponent();
            startProgressBar();
        }
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 30; i++)
            {
                while (i != Counter.Count) { }
                (sender as BackgroundWorker)?.ReportProgress(i * 3);
                if (Counter.Count == 29)
                {
                    (sender as BackgroundWorker)?.ReportProgress(100);
                    MessageBox.Show("Завантаження всіх слів успішно завершено!");
                    Dispatcher.Invoke(() => { Close(); });
                }
            }
        }
        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e) => progressBar.Value = e.ProgressPercentage;
        private void startProgressBar()
        {
            var worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork!;
            worker.ProgressChanged += worker_ProgressChanged!;
            worker.RunWorkerAsync();
        }
    }
}
