using System.Windows;
using System.Windows.Controls;
using NexaRetail.ViewModels;

namespace NexaRetail.Views
{
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {
            InitializeComponent();

            DataContext = new DashboardViewModel();
        }

        private void SalesButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow =
                Application.Current.MainWindow as MainWindow;

            if (mainWindow != null)
            {
                mainWindow.Content = new SalesView();
            }
        }
    }
}
