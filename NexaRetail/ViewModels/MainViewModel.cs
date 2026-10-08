using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using NexaRetail.Commands;

namespace NexaRetail.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private object _currentView;


        // =========================================================
        // CURRENT VIEW
        // =========================================================

        public object CurrentView
        {
            get
            {
                return _currentView;
            }
            set
            {
                if (_currentView != value)
                {
                    _currentView = value;

                    OnPropertyChanged(nameof(CurrentView));
                }
            }
        }


        // =========================================================
        // DASHBOARD COMMAND
        // =========================================================

        public ICommand DashboardCommand { get; }


        // =========================================================
        // SALES COMMAND
        // =========================================================

        public ICommand SalesCommand { get; }


        // =========================================================
        // CONSTRUCTOR
        // =========================================================

        public MainViewModel()
        {
            DashboardCommand =
                new RelayCommand(
                    ShowDashboard);

            SalesCommand =
                new RelayCommand(
                    ShowSales);


            // Start application with Login
            ShowLogin();
        }


        // =========================================================
        // LOGIN
        // =========================================================

        private void ShowLogin()
        {
            LoginViewModel loginViewModel =
                new LoginViewModel();

            loginViewModel.LoginSucceeded +=
                LoginViewModel_LoginSucceeded;

            CurrentView =
                loginViewModel;
        }


        // =========================================================
        // LOGIN SUCCESS
        // =========================================================

        private void LoginViewModel_LoginSucceeded()
        {
            ShowDashboard();
        }


        // =========================================================
        // DASHBOARD
        // =========================================================

        public void ShowDashboard()
        {
            CurrentView =
                new DashboardViewModel(this);
        }


        // =========================================================
        // SALES
        // =========================================================

        public void ShowSales()
        {
            CurrentView =
                new SalesViewModel();
        }


        // =========================================================
        // PROPERTY CHANGED
        // =========================================================

        public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyChanged(
            [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}