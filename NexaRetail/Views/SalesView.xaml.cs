using System.Windows;
using System.Windows.Controls;
using NexaRetail.ViewModels;

namespace NexaRetail.Views
{
    public partial class SalesView : UserControl
    {
        public SalesView()
        {
            InitializeComponent();

            DataContext = new SalesViewModel();
        }

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow =
                Application.Current.MainWindow as MainWindow;

            if (mainWindow != null)
            {
                mainWindow.Content = new DashboardView();
            }
        }
    }
}
