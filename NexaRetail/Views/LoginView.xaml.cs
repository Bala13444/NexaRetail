using System.Windows;
using System.Windows.Controls;
using NexaRetail.ViewModels;

namespace NexaRetail.Views
{
    public partial class LoginView : UserControl
    {
        private readonly LoginViewModel _viewModel;

        public LoginView()
        {
            InitializeComponent();

            _viewModel = new LoginViewModel();

            DataContext = _viewModel;

            _viewModel.LoginSucceeded += LoginSucceeded;
        }

        private void LoginSucceeded()
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